using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Static_Data;
using Discord;

namespace AtlasBot.Loggers
{
    public static class DiscordLogger
    {
        public static async void Log(string module, string message)
        {
            //TODO Replace with bot owner Id from config
            var user = DiscordManager.Client.GetUser(111211693870161920);
            if (user != null)
                await user.SendMessageAsync($"{module} caused error: {message}");
        }
    }
}
