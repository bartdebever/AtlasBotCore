using System;
using System.Collections.Generic;
using System.Text;
using Discord;

namespace AtlasBot.Loggers.Messages
{
    public class ModuleLogMessage
    {
        public string Module { get; set; }
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }

        public ModuleLogMessage()
        {
            
        }

        public ModuleLogMessage(string module, string message, LogSeverity severity = LogSeverity.Info)
        {
            this.Module = module;
            this.Message = message;
            this.Severity = severity;
        }
    }
}
