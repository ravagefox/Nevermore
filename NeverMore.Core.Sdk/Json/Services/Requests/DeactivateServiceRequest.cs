// Source: DeactivateServiceRequest
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
    /// A request made by a user to deactivate a service 
    /// on their account
    /// </summary>
    public sealed class DeactivateServiceRequest
    {
        /// <summary>
        /// Gets or sets the id for the service
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the id of the account which
        /// needs the service deactivated
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the owner of the service to deactivate
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
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_SERVICE_DEACTIVATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
