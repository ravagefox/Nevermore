// Source: CreateServiceRequest
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

namespace Nevermore.Core.Sdk.Json.Services.Requests
{
    /// <summary>
    /// A request used to create a service
    /// </summary>
    public sealed class CreateServiceRequest
    {
        /// <summary>
        /// Gets or sets the name of the service
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description for the service.
        /// (This is used for management of the service)
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the state of whether
        /// the service requires a subscription or not
        /// </summary>
        [JsonProperty(PropertyName = "isFreeService")]
        public bool IsFreeService { get; set; } = true;
        /// <summary>
        /// Gets or sets the owner of the newly created service
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "ownerId")]
        public Guid OwnerId { get; set; }


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_SERVICE_CREATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
