// Source: AccountUpdateType
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
    /// Properties that can be updated on the users account
    /// </summary>
    public enum AccountUpdateType : int
    {
#pragma warning disable
        None,
        Email,
        Password,
        PhoneNumber, // TODO: implement phone number security verification
        MFAEnablement,
        ResetPassword,
#pragma warning restore
    }


}
