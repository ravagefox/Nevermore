// Source: LogInfo
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

using Crexium.Net.Http.Security.Authenticators;
using System;
using System.Diagnostics;

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Provides support for basic log information
    /// </summary>
    public sealed class LogInfo : EventArgs
    {
#pragma warning disable
        public string RemoteAddress { get; set; }
        public SupportedHttpAuthenticators AuthMethod { get; set; }
        public EventLogEntryType EntryType { get; set; }
        public string ErrorMessage { get; set; }
        public int Priority { get; set; } = -5;
    }


}
