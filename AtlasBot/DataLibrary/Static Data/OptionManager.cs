using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataLibrary.Static_Data
{
    public static class OptionManager
    {
        private static string discordAPIKey = "";
        private static string riotAPIKey = "";
        private static string smashHash = "";
        private static string databaseConnectionString = "";
        private static string riotDatabaseConnectionString = "";
        private static string speedrunAPIKey = "";
        private static string smashggTrackerContext = "";
        private static bool initialized = true;

        public static string SmashggTrackerContext
        {
            get
            {
                if(!initialized)
                    Initialize();
                return smashggTrackerContext;
            }
        }

        public static string DiscordKey
        {
            get
            {
                if (!initialized)
                {
                    Initialize();
                }
                return discordAPIKey;
            }
        }

        public static string RiotKey
        {
            get
            {
                if (!initialized)
                {
                    Initialize();
                }
                return riotAPIKey;
            }
        }

        public static string SmashHash
        {
            get
            {
                if (!initialized)
                {
                    Initialize();
                }
                return smashHash;
            }
        }

        public static string GeneralDatabase
        {
            get
            {
                if (!initialized)
                    Initialize();
                return databaseConnectionString;
            }
        }

        public static string RiotDatabase
        {
            get
            {
                if (!initialized)
                    Initialize();
                return riotDatabaseConnectionString;
            }
        }

        public static string SpeedrunCom
        {
            get
            {
                if (!initialized)
                    Initialize();
                return speedrunAPIKey;
            }
        }

        public static void Initialize()
        {
            using (StreamReader file = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/Discordbot/Configuration.json")) 
            //TODO if not found > Make file
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject ob = (JObject)JToken.ReadFrom(reader);
                discordAPIKey = ob.GetValue("DiscordAPI").ToString();
                riotAPIKey = ob.GetValue("RiotAPI").ToString();
                smashHash = ob.GetValue("SmashHash").ToString();
                databaseConnectionString = ob.GetValue("GeneralDatabase").ToString();
                riotDatabaseConnectionString = ob.GetValue("RiotDatabase").ToString();
                speedrunAPIKey = ob.GetValue("SpeedrunAPI").ToString();
            }
            initialized = true;
        }
    }
}
