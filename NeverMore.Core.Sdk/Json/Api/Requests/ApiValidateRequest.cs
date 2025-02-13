// Source: ApiValidateRequest
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

namespace Nevermore.Core.Sdk.Json.Api.Requests
{
    /// <summary>
    /// A request to validate a key against the security
    /// database
    /// </summary>
    public sealed class ApiValidateRequest
    {
        /// <summary>
        /// Gets or sets the key specific
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }
        /// <summary>
        /// Gets or sets the secret that will be used
        /// to verify the key
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "apiSecret")]
        public string ApiSecret { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_APIKEY_VALIDATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
