// Source: AccountInfo
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

namespace Nevermore.Core.Sdk.DataModels
{
    /// <summary>
    /// Definition for base level account information
    /// </summary>
    public sealed class AccountInfo : IRefId
    {
        /// <summary>
        /// Gets or sets the id of the account
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the username of the account.
        /// (Don't mistake this for the name of the creator)
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the account
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password that the account has
        /// (This property is always omitted from JSON
        /// serialization)
        /// </summary>
        [JsonIgnore]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the salt used by the password.
        /// (This property is always omitted from JSON
        /// serialization)
        /// </summary>
        [JsonIgnore]
        [JsonProperty(PropertyName = "passwordSalt")]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the current account flags
        /// </summary>
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "accountFlags")]
        public AccountFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the date and time that the 
        /// account was created in UTC
        /// </summary>
        [JsonProperty(PropertyName = "createdTimeUtc")]
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the last access date and time
        /// in UTC
        /// </summary>
        [JsonProperty(PropertyName = "lastAccessUtc")]
        public DateTime LastAccess { get; set; }
    }
}
