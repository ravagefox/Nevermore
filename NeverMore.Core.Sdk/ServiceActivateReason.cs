// Source: ServiceActivateReason
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
    /// Activate reasons used when a client is attempting 
    /// to activate a service.
    /// </summary>
    public enum ServiceActivateReason
    {
        /// <summary>
        /// OK
        /// </summary>
        Success,

        /// <summary>
        /// Service attempting to activate, is being attempted by
        /// an unauthorised account
        /// </summary>
        IncorrectOwner,

        /// <summary>
        /// General server failure, try again later
        /// </summary>
        GeneralFailure,

        /// <summary>
        /// The service requires a payment to be made to 
        /// activate, this includes subscriptions and one time
        /// payments
        /// </summary>
        PaymentRequired,

        /// <summary>
        /// The country, or locale attempting to activate is
        /// forbidden
        /// </summary>
        RegionForbidden,

        /// <summary>
        /// The service has already been activated on the target
        /// account
        /// </summary>
        ServiceAlreadyActivated,
    }
}
