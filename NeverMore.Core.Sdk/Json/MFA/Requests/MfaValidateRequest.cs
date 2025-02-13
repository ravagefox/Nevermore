// Source: MfaValidateRequest
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

namespace Nevermore.Core.Sdk.Json.MFA.Requests
{
    /// <summary>
    /// A request to provide two factor authentication
    /// </summary>
    public sealed class MfaValidateRequest
    {
        /// <summary>
        /// Gets or sets the token that will be used
        /// to validate against
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the account id to create
        /// a validating token for
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_MFA_CHECK);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
