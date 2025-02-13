// Source: INevermorePlugin
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

using Crexium.IO.Plugins;
using Crexium.Net.Api;
using Crexium.Net.IO;
using Nevermore.Core.Sdk.Net;
using System;
using System.Collections.Generic;

namespace Nevermore.Core.Sdk
{
    /// <summary>
    /// Provides accessibility for new additional programs that 
    /// can run within the Nevermore
    /// </summary>
    public abstract class NevermorePlugin : MarshalByRefObject, IPluginType
    {
        /// <summary>
        /// Gets or sets the custom hooks that the plugin will use.
        /// </summary>
        public Dictionary<uint, ApiMethod<NevermoreClient, PacketDecoder>> CustomHooks { get; } =
            new Dictionary<uint, ApiMethod<NevermoreClient, PacketDecoder>>();
        /// <inheritdoc/>


        public abstract Guid Id { get; }
        /// <inheritdoc/>
        public abstract string Name { get; }


        /// <summary>
        /// Initializes the plugin
        /// </summary>
        public abstract void Initialize(object startupParameters);

        /// <summary>
        /// Unloads the current context from Nevermore.
        /// </summary>
        public abstract void Unload();
    }
}
