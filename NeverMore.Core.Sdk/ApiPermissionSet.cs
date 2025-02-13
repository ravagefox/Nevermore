// Source: ApiPermissionSet
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
    /// Permissions used by the Client Api-Secret authentication
    /// method
    /// </summary>
    public enum ApiPermissionSet : int
    {
        /// <summary>
        /// The Api key is currently inactive and cannot be used
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// The api key provided can only read data
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// The api key can only write data
        /// </summary>
        WriteOnly = 2,
        /// <summary>
        /// The api key can read and write data
        /// </summary>
        ReadWrite = 3,

        /// <summary>
        /// Full control is only limited to the creator user
        /// to prevent any unauthorised management of assets
        /// </summary>
        FullControl = 4,
    }
}
