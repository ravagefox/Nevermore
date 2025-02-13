// Source: ActivateServiceRequest
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
    /// A request to submit for a newly activated service on
    /// a user's account
    /// </summary>
    public sealed class ActivateServiceRequest
    {
        /// <summary>
        /// Gets or sets the service to activate
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the account id to activate on
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }
        /// <summary>
        /// Gets or sets the username or email to locate,
        /// if an account id was not provided.
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// Gets or sets the owner id of the service to activate.
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
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_SERVICE_ACTIVATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
