// Source: ApiListResponse
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
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Api.Responses
{
    /// <summary>
    /// A response used to display all the keys that 
    /// are accessible to the requesting user
    /// </summary>
    public sealed class ApiListResponse : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the listed response
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// (THIS PROPERTY IS IGNORED)
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the packet.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the list of API keys that
        /// were found on the account.
        /// </summary>
        [JsonProperty(PropertyName = "apiKeyIds")]
        public Guid[] ApiKeyIds { get; set; } = Array.Empty<Guid>();


        /// <summary>
        /// Returns the current instance as a serialized JSON object.
        /// </summary>
        /// <param name="indent"></param>
        /// <returns></returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }

        /// <summary>
        /// When overriden in a derrived class, serializes the current instance
        /// to json format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString(true);
        }
    }
}
