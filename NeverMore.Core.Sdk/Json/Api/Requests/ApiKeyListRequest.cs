// Source: ApiKeyListRequest
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
using Crexium.IO.Json.JsonConverters;
using Crexium.Net.IO;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Api.Requests
{
    /// <summary>
    /// A request used by the administrator to retrieve
    /// the API keys associated with the account id
    /// </summary>
    public sealed class ApiKeyListRequest
    {
        /// <summary>
        /// Gets or sets the account ownership
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid OwnerId { get; set; }
        /// <summary>
        /// Gets or sets the level of permissions
        /// that will be requested
        /// </summary>
        [IsRequired]
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "permissionSet")]
        public ApiPermissionSet MinPermissions { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_APIKEY_LIST);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
