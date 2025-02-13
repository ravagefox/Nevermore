// Source: ContainerCreateRequest
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
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Containers.Requests
{
    /// <summary>
    /// A request body for creating containers
    /// </summary>
    public sealed class ContainerCreateRequest
    {
        /// <summary>
        /// Gets or sets the service id to create
        /// the container for
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        [IsRequired]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the account for verification of 
        /// container creation
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        [IsRequired]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the status of the packet.
        /// </summary>
        public bool Success { get; set; } = false;

    }
}
