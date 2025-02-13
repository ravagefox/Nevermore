// Source: FlexMessageAttribute
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

using Crexium.Net.Api;

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Default instance for exposing methods to handle data
    /// </summary>
    public class FlexMessageAttribute : ApiMethodAttribute
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public FlexMessageAttribute() { }

        /// <summary>
        /// Initializes a new instance with the given op code
        /// </summary>
        /// <param name="code"></param>
        public FlexMessageAttribute(NeverMoreAuthOpCodes code)
            : base((uint)code) { }

        /// <summary>
        /// Initializes a new instance with a custom hook op code
        /// </summary>
        /// <param name="code"></param>
        public FlexMessageAttribute(uint code) : base(code) { }
    }
}
