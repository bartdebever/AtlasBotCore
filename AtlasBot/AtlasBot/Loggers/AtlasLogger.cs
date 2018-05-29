using System;
using System.Collections.Generic;
using System.Text;
using AtlasBot.Loggers.Messages;
using Discord;

namespace AtlasBot.Loggers
{
    public static class AtlasLogger
    {
        public static void Log(ModuleLogMessage message)
        {
            Log(message.Message, message.Module, message.Severity);
        }
        private static void Log(string message, string module, LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {module}: {message}");
            Console.ResetColor();
        }
    }
}
