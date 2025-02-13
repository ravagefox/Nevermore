// Source: AccountUpdateRequest
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
using Crexium.IO.Json.JsonConverters;
using Crexium.Net.IO;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Account.Requests
{
    /// <summary>
    /// A request used to update account information
    /// </summary>
    public sealed class AccountUpdateRequest
    {
        /// <summary>
        /// Gets or sets the account id to update
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid AccountId { get; set; }
        /// <summary>
        /// Gets or sets the new data to be submitted
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
        /// <summary>
        /// Gets or sets the confirmation key of any 
        /// pre-existing data that needs to be verified for
        /// a change to take place. ie password change, or email update
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "confirmationKey")]
        public string ConfirmationKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the property to update on the account
        /// </summary>
        [IsRequired]
        [JsonConverter(typeof(PerfektStringEnumConverter))]
        [JsonProperty(PropertyName = "accountUpdateType")]
        public AccountUpdateType UpdateType { get; set; }

        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns>Returns the encoded data packet</returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_ACCOUNT_UPDATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
