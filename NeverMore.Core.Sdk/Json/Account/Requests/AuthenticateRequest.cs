// Source: AuthenticateRequest
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

namespace Nevermore.Core.Sdk.Json.Account.Requests
{
    /// <summary>
    /// A request used to authenticate a user
    /// </summary>
    public sealed class AuthenticateRequest 
    {
        /// <summary>
        /// Gets or sets the service the account
        /// is trying to log into
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the username or email
        /// </summary>
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string UsernameOrEmail { get; set; }
        /// <summary>
        /// Gets or sets the account id, in place of 
        /// <see cref="UsernameOrEmail"/> being null, or empty
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }
        /// <summary>
        /// Gets or sets the password that was submitted
        /// to authenticate with
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns>Returns the encoded data packet</returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_AUTHENTICATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
