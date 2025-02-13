// Source: NevermoreClient
/* 
   ---------------------------------------------------------------
                        CREXIUM PTY LTD
   ---------------------------------------------------------------

     The software is provided 'AS IS', without warranty of any kind,
   express or implied, including but not limited to the warrenties
   of merchantability, fitness for a particular purpose and
   noninfringement. In no event shall the authors or copyright
   holders be liable for any claim, damages, or other liability,
   whether in an action of contract, tort, or otherwise, arising
   from, out of or in connection with the software or the use of
   other dealings in the software.
*/

using Crexium.Core.Cryptography;
using Crexium.Net;
using Crexium.Net.Api;
using Crexium.Net.IO;
using Nevermore.Core.Sdk.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Nevermore.Core.Sdk.Net
{
    /// <summary>
    /// Provides a Client access point for communications with the 
    /// Nevermore Services
    /// </summary>
    public sealed class NevermoreClient : NetClient
    {
        /// <summary>
        /// Gets or sets the RSA encryption handler
        /// </summary>
        public RsaCipher Rsa { get; private set; }
        /// <summary>
        /// Gets or sets whether the client is currently encrypted
        /// </summary>
        public bool IsEncrypted { get; private set; }


        private PacketHandler<NevermoreClient, PacketDecoder> ApiHandler { get; }


        /// <summary>
        /// Initializes a new instance, with the connection point
        /// to the server
        /// </summary>
        public NevermoreClient() :
            base(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            this.ApiHandler = new PacketHandler<NevermoreClient, PacketDecoder>();
            //foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    var types = TypeResolver.Instance.GetTypes(asm);
            //    if (types.Any())
            //    {
            //        this.ApiHandler.RegisterTypes(types);
            //    }
            //}
        }

        /// <summary>
        /// Import a set of types into the client.
        /// </summary>
        /// <param name="types"></param>
        public void ImportAsmTypes(IEnumerable<Type> types)
        {
            this.ApiHandler.RegisterTypes(types);
        }

        /// <summary>
        /// When overriden in a derrived class, handles the connection
        /// state when the client has connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnClientConnected(object sender, EventArgs e)
        {
            // 1. Receive the encryption settings
            var bitBuffer = new byte[1];
            var size = this.TcpSocket.Receive(bitBuffer);
            if (size == 1)
            {
                var useEncryption = bitBuffer[0] == 0x01;
                if (!useEncryption)
                {
                    base.OnClientConnected(sender, e);
                    return;
                }

                bitBuffer[0] = 0x00;
                Array.Resize(ref bitBuffer, ushort.MaxValue);

                // 2. Process public key information
                size = this.TcpSocket.Receive(bitBuffer);
                if (size > 0)
                {
                    Array.Resize(ref bitBuffer, size);
                    this.Rsa = new RsaCipher()
                    {
                        PublicKey = bitBuffer,
                    };

                    // 3. Encrypt the symmetric key and send to server.
                    var symmetricKey = Guid.NewGuid().ToByteArray();
                    size = this.TcpSocket.Send(this.Rsa.Encrypt(symmetricKey));
                    if (size == 0)
                    {
                        this.Disconnect();
                        return;
                    }

                    this.Aes = new AesCipher(symmetricKey);
                    this.IsEncrypted = true;
                }
            }

            base.OnClientConnected(sender, e);
        }

        /// <summary>
        /// When overriden in a derrived class, handles the data that was
        /// sent to the server
        /// </summary>
        /// <param name="bytesSent"></param>
        /// <param name="data"></param>
        /// <param name="ep"></param>
        protected override void OnSendTo(int bytesSent, byte[] data, IPEndPoint ep)
        {
        }

        /// <summary>
        /// When overriden in a derrived class, handles the incoming data
        /// from the server
        /// </summary>
        /// <param name="bytesReceived"></param>
        /// <param name="buffer"></param>
        protected override void OnReceiveFrom(int bytesReceived, byte[] buffer)
        {
            var data = buffer;
            if (this.IsEncrypted)
            {
                this.Aes.Data = buffer;
                this.Aes.DecryptAsync().GetAwaiter().GetResult();
                data = this.Aes.Data;
            }

            using (var packet = new PacketDecoder(data))
            {
                //var data = packet.ToString();

                var state = packet.ReadBoolean();
                if (!state)
                {
                    var dataError = packet.ReadJson<JsonDataErrorResponse>();
                    Console.WriteLine(dataError.Name);
                    if (dataError.Errors != null && dataError.Errors.Length > 0)
                    {
                        foreach (var error in dataError.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }

                    packet.Error = dataError;
                }

                packet.WasSuccess = state;
                if (!this.ApiHandler.TryInvoke(this, packet))
                {
                    // Do something with the error code.
                    Console.WriteLine("Failed to handle Flex Packet: ID: " + packet.OpCode);
                }

            }

        }

    }
}
