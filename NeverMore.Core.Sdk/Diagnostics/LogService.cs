// Source: LogService
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

using Crexium.Diagnostics;
using Crexium.Net.Http.Security.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security;
using System.Xml.Serialization;

namespace Nevermore.Core.Sdk.Diagnostics
{
    public class LogService : ILogService<LogInfo>
    {

        public Guid Id { get; }

        public string Name { get; }



        public event EventHandler<LogInfo> WarningCreated;
        public event EventHandler<LogInfo> ErrorCreated;
        public event EventHandler<LogInfo> InformationCreated;



        public LogService(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();

            bool sourceExists;
            try
            {
                sourceExists = EventLog.SourceExists("Nevermore");
                if (!sourceExists)
                {
                    EventLog.CreateEventSource("Nevermore", this.Name);
                }
            }
            catch (ArgumentException) { }
            catch (SecurityException)
            {
            }
        }


        public void Add(object graph, EventLogEntryType type)
        {
            var xmlData = string.Empty;

            var xmlSerializer = new XmlSerializer(graph.GetType());
            using (var ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, graph);
                _ = ms.Seek(0, SeekOrigin.Begin);

                using (var sw = new StreamReader(ms))
                {
                    xmlData = sw.ReadToEnd();
                    sw.Close();
                }

                ms?.Close();
            }

            EventLog.WriteEntry(this.Name, xmlData, type);
            // Console.WriteLine(xmlData);
        }

        public void Add(LogInfo info)
        {
            var xmlData = string.Empty;
            var xmlSerializer = new XmlSerializer(typeof(LogInfo));

            using (var ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, info);
                _ = ms.Seek(0, SeekOrigin.Begin);

                using (var sw = new StreamReader(ms))
                {
                    xmlData = sw.ReadToEnd();
                }
            }

            EventLog.WriteEntry(this.Name, xmlData, info.EntryType);

            var fmt = "[{0}] {1}: {2}";
            var format = string.Format(fmt, DateTime.Now, info.EntryType, info.ErrorMessage);
            var consoleColor = Console.ForegroundColor;
            switch (info.EntryType)
            {
                case EventLogEntryType.Information:
                    this.InformationCreated?.Invoke(this, info);
                    break;
                case EventLogEntryType.Warning:
                    consoleColor = ConsoleColor.Yellow;
                    this.WarningCreated?.Invoke(this, info);
                    break;
                case EventLogEntryType.Error:
                    consoleColor = ConsoleColor.Red;
                    this.ErrorCreated?.Invoke(this, info);
                    break;
            }

            Console.ForegroundColor = consoleColor;
            Console.WriteLine(format);
            Console.ResetColor();
        }

        public void Add(string message, EventLogEntryType type = EventLogEntryType.Information)
        {
            this.Add(new LogInfo()
            {
                AuthMethod = SupportedHttpAuthenticators.Anonymous,
                EntryType = type,
                ErrorMessage = message,
                RemoteAddress = IPAddress.Any.ToString(),
            });
        }

        public IReadOnlyList<LogInfo> GetLogs(params ILogFilter<LogInfo>[] filterConditions)
        {
            throw new Exception("Always refer to the Windows Event Viewer.");
        }
    }
}
