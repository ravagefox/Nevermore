// Source: NevermoreFlexParams
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

using Crexium.Core;
using Crexium.Net.Flex;
using System;

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Startup parameters for the flex environment.
    /// </summary>
    public sealed class NevermoreFlexParams : Singleton<NevermoreFlexParams>, IFlexStartParams
    {
        /// <summary>
        /// Gets the current service provider for the application.
        /// </summary>
        public IServiceProvider ServiceProvider => Crexium.Core.ServiceProvider.Instance;
        /// <summary>
        /// Gets the current flex instance.
        /// </summary>
        public FlexHandler FlexHandler => FlexHandler.Instance;
    }
}
