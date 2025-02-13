// Source: AuthenticateResponse
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

namespace Nevermore.Core.Sdk.Json.Account.Responses
{
    /// <summary>
    /// A response used for the authentication request status
    /// for the request
    /// </summary>
    public sealed class AuthenticateResponse : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the response
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the credential that was used for the response.
        /// </summary>
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the packet.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Success { get; set; } = false;

        /// <summary>
        /// Gets or sets the authentication response code
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "code")]
        public LoginStatusCode Code { get; set; }

        /// <summary>
        /// Gets or sets the account id that was used to login.
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the session token value.
        /// </summary>
        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }



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
