// Source: ApiKeyDeleteRequest
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

using Crexium.IO.Json;
using Crexium.Net.IO;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Api.Requests
{
    /// <summary>
    /// A request used to delete a key from the security
    /// database
    /// </summary>
    public sealed class ApiKeyDeleteRequest
    {
        /// <summary>
        /// Gets or sets the API Key Id that will
        /// be deleted
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid ApiKeyId { get; set; }
        /// <summary>
        /// Gets or sets the account owner that is making
        /// the delete request
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "ownerId")]
        public Guid AccountId { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_APIKEY_DELETE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
