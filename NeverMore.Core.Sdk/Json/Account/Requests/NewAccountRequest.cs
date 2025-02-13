// Source: NewAccountRequest
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
using Crexium.Net.IO;
using Newtonsoft.Json;
using System;

namespace Nevermore.Core.Sdk.Json.Account.Requests
{
    /// <summary>
    /// A request to submit account creation
    /// </summary>
    public sealed class NewAccountRequest
    {
        /// <summary>
        /// Gets or sets the username or email of the 
        /// new account
        /// </summary>
        [IsRequired]
        [JsonProperty(PropertyName = "usernameOrEmail")]
        public string UsernameOrEmail { get; set; }
        /// <summary>
        /// Gets or sets the password that will be used
        /// when creating a new account.
        /// (If none is specified, then the account will
        /// automatically generate a password)
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the optional services that
        /// will be automatically applied to the account
        /// </summary>
        [JsonProperty(PropertyName = "servicesToActivate")]
        public Guid[] ServicesToActivate { get; set; } = Array.Empty<Guid>();


        /// <summary>
        /// Returns the encoder that will be used to serialize the data
        /// </summary>
        /// <returns></returns>
        public PacketEncoder GetEncoder()
        {
            var encoder = new PacketEncoder((uint)NeverMoreAuthOpCodes.CMSG_ACCOUNT_CREATE);
            encoder.WriteAsJson(this);

            return encoder;
        }
    }
}
