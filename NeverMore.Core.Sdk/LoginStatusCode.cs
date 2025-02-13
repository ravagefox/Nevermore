// Source: LoginStatusCode
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

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Status codes which are prompted when a user authenticates with 
    /// the server
    /// </summary>
    public enum LoginStatusCode
    {
        /// <summary>
        /// Successfully authenticated
        /// </summary>
        Success,
        /// <summary>
        /// Trial has expired and the account must make payment
        /// </summary>
        TrialExpired,
        /// <summary>
        /// The user supplied invalid credentials
        /// </summary>
        InvalidCredentials,
        /// <summary>
        /// The service is blocked from access
        /// </summary>
        ServiceBlocked,
        /// <summary>
        /// The account requires a form of two factor authentication
        /// </summary>
        RequiresMfa,
        /// <summary>
        /// The account is currently banned from access
        /// </summary>
        IsBanned,
        /// <summary>
        /// The account requires a payment to be made to regain access
        /// </summary>
        RequiresPayment,
        /// <summary>
        /// The two factor code provided was invalid
        /// </summary>
        InvalidMfaCode,
    }
}
