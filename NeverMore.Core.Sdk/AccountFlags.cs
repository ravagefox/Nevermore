// Source: AccountFlags
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

using System;

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Flags to display access for a users account
    /// </summary>
    [Flags]
    public enum AccountFlags : int
    {
#pragma warning disable
        None = 0,

        IsUser = 1,
        IsAdmin = 2,

        IsBanned = 4,
        PaymentRequired = 8,
        IsMfaEnabled = 16,

        /// <summary>
        /// A user must change their password when they log
        /// into any service for the first time
        /// </summary>
        PasswordChangeRequired = 32,

        EmailVerificationRequired = 64,
#pragma warning restore
    }
}
