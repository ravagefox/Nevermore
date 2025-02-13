// Source: CreateApiKeyRequest
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
    /// A request used to create an API key and 
    /// attach it to a service
    /// </summary>
    public sealed class CreateApiKeyRequest
    {
        /// <summary>
        /// Gets or sets the owner that will 
        /// have the key bound to
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "ownerId")]
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the service id that the key 
        /// will be bound to
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the permission level of the 
        /// newly created api key
        /// </summary>
        //[IsRequired]
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "permissionSet")]
        public ApiPermissionSet Permissions { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_APIKEY_CREATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
