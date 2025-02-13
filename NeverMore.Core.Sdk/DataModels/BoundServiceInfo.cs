// Source: BoundServiceInfo
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
using Crexium.IO.Sql;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.DataModels
{
    /// <summary>
    /// Definition of whether a user has access to a service
    /// </summary>
    public sealed class BoundServiceInfo : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the service to bind
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the service.
        /// (This is ignored)
        /// </summary>
        [JsonIgnore]
        [SqlOmitProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the service name that was bound
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the account that has the service
        /// currently bound
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }
        /// <summary>
        /// Gets or sets the assigned date and time that 
        /// the service was activated in UTC
        /// </summary>
        [JsonProperty(PropertyName = "assignedDateTimeUtc")]
        public DateTime AssignedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the current state of the service
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "serviceState")]
        public BoundServiceState State { get; set; }
        /// <summary>
        /// Gets or sets the trial duration for the bound
        /// service in ticks
        /// </summary>
        [JsonProperty(PropertyName = "trialTimeTicks")]
        public long TrialDuration { get; set; }
    }
}
