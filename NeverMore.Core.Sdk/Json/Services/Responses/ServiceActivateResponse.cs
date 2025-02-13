// Source: ServiceActivateResponse
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

namespace Nevermore.Core.Sdk.Json.Services.Responses
{
    /// <summary>
    /// General response for when a service has been activated
    /// </summary>
    public sealed class ServiceActivateResponse : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the response
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username or email that was
        /// activated
        /// </summary>
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the activation status for the account
        /// specified
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public ServiceActivateReason Status { get; set; }
    }
}
