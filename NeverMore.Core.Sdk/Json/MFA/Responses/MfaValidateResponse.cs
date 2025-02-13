// Source: MfaValidateResponse
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
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.MFA.Responses
{
    /// <summary>
    /// A response for validated MFA codes.
    /// </summary>
    public sealed class MfaValidateResponse : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the packet
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the account used to validate the request.
        /// </summary>
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the packet.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the account id that was used to validate 
        /// the request.
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the successful status message for 
        /// the validation.
        /// </summary>
        [JsonProperty(PropertyName = "loginStatus")]
        public LoginStatusCode Code { get; set; }
    }
}
