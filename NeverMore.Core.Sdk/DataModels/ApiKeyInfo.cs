// Source: ApiKeyInfo
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
    /// Definition for an API key
    /// </summary>
    public sealed class ApiKeyInfo : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the api key
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the key.
        /// (This is ignored)
        /// </summary>
        [JsonIgnore]
        [SqlOmitProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permissions of the api key
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "permissions")]
        public ApiPermissionSet Permissions { get; set; }
        /// <summary>
        /// Gets or sets the creator account id
        /// </summary>
        [JsonProperty(PropertyName = "creatorId")]
        public Guid CreatorId { get; set; }
        /// <summary>
        /// Gets or sets the service that this key will
        /// be used for
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the key that is attached
        /// to the current instance
        /// </summary>
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }
        /// <summary>
        /// Gets or sets the api key secret that is
        /// attached to the current instance
        /// </summary>
        [JsonProperty(PropertyName = "apiSecret")]
        public string SecretKey { get; set; }
        /// <summary>
        /// Gets or sets the flags of the current 
        /// instance
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "flags")]
        public ApiKeyFlags Flags { get; set; }
    }
}
