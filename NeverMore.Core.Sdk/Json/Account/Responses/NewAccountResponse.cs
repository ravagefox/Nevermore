// Source: NewAccountResponse
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

namespace Nevermore.Core.Sdk.Json.Account.Responses
{
    /// <summary>
    /// Provides a response for when an account has been newly created.
    /// </summary>
    public sealed class NewAccountResponse : IRefId
    {
        /// <summary>
        /// Gets or sets the Id of the response.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the account user credential.
        /// </summary>
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the packet.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the account of the newly created account.
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }



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
