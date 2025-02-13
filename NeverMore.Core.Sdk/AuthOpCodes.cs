// Source: AuthOpCodes
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
    /// Operation codes that are used to invoke an action on
    /// the server
    /// </summary>
    public enum NeverMoreAuthOpCodes : uint
    {
#pragma warning disable
        None,

        CMSG_AUTHENTICATE,
        SMSG_AUTHENTICATE,

        CMSG_ACCOUNT_CREATE,
        SMSG_ACCOUNT_CREATE,

        CMSG_MFA_CHECK,
        SMSG_MFA_CHECK,

        CMSG_ACCOUNT_UPDATE,
        SMSG_ACCOUNT_UPDATE,

        CMSG_SERVICE_CREATE,
        SMSG_SERVICE_CREATE,

        CMSG_SERVICE_ACTIVATE,
        SMSG_SERVICE_ACTIVATE,

        CMSG_SERVICE_DEACTIVATE,
        SMSG_SERVICE_DEACTIVATE,

        CMSG_APIKEY_CREATE,
        SMSG_APIKEY_CREATE,
        CMSG_APIKEY_LIST,
        SMSG_APIKEY_LIST,
        CMSG_APIKEY_DELETE,
        SMSG_APIKEY_DELETE,

        CMSG_APIKEY_VALIDATE,
        SMSG_APIKEY_VALIDATE,
        CMSG_HEARTBEAT,

#pragma warning enable
    }
}
