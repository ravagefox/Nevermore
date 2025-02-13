// Source: ServiceInfo
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

using Crexium.Core;
using Crexium.IO.Json.JsonConverters;
using Crexium.Net.Http.Security.Authenticators;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.DataModels
{
    /// <summary>
    /// Definition for management of service information
    /// </summary>
    public sealed class ServiceInfo : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the service.
        /// (In all events of newly created ones, this is 
        /// automatically generated)
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the service
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description of the 
        /// service
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the time in UTC of when
        /// the service was created
        /// </summary>
        [JsonProperty(PropertyName = "createdUtc")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the supported authentication 
        /// policies of the service
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "supportedHttpAuthentication")]
        public SupportedHttpAuthenticators SupportedAuthentication { get; set; }
        /// <summary>
        /// Gets or sets the flags of the service
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "serviceFlags")]
        public ServiceInfoFlags Flags { get; set; }
        /// <summary>
        /// Gets or sets the account that owns the service
        /// </summary>
        [JsonProperty(PropertyName = "accountOwnerId")]
        public Guid AccountOwnerId { get; set; }
        /// <summary>
        /// Gets or sets the agent who authorised the creation
        /// </summary>
        [JsonProperty(PropertyName = "serviceAgentId")]
        public Guid ServiceAgentId { get; set; }

        /// <summary>
        /// Gets or sets the services website, this is used primarily
        /// for password resets
        /// </summary>
        [JsonProperty(PropertyName = "serviceWebsite")]
        public string ServiceWebsite { get; set; }
    }
}
