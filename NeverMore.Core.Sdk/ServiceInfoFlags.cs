// Source: ServiceInfoFlags
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
    /// Flags to describe service information
    /// </summary>
    [Flags]
    public enum ServiceInfoFlags : int
    {
        /// <summary>
        /// No flags applied
        /// </summary>
        None = 0,

        /// <summary>
        /// The service is provided freely
        /// </summary>
        IsFree = 1,
        /// <summary>
        /// The service requires a subscription to use
        /// </summary>
        IsSubscription = 2,
        /// <summary>
        /// The service is currently active, no active flag means its disabled.
        /// </summary>
        IsActive = 4,
    }

    /// <summary>
    /// Status for a service which is attached to an account
    /// </summary>
    public enum BoundServiceState : int
    {
        /// <summary>
        /// No state could be identified
        /// </summary>
        Invalid,

        /// <summary>
        /// The service is currently frozen to the user
        /// </summary>
        IsFrozen,
        /// <summary>
        /// Service is currently active without interruption
        /// </summary>
        IsActive,
        /// <summary>
        /// A trial period has been applied
        /// </summary>
        IsTrial,
        /// <summary>
        /// Payment is required to reactivate the service on the account
        /// </summary>
        PaymentRequired,
        /// <summary>
        /// The service is currently blocked until this is resolved
        /// </summary>
        IsBanned,
    }
}
