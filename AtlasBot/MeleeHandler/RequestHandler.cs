using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeleeHandler.DataType;
using Newtonsoft.Json;

namespace MeleeHandler
{
    public class RequestHandler
    {
        private static List<MeleeTechnique> cachedTechs = null;
        private static List<MeleeCharacter> chachedCharacters = null;
        public static MeleeCharacter GetCharacter(string name)
        {
            var json = RequestBuilder.GetCharacter();
            if (chachedCharacters == null)
            {
                chachedCharacters = JsonConvert.DeserializeObject<List<MeleeCharacter>>(json);
            }
            return chachedCharacters.FirstOrDefault(x=> x.name.ToLower().Normalize().Replace(" ","").Equals(name.ToLower().Replace(" ", "").Normalize()));
        }

        public static MeleeTechnique GetTechnique(string name)
        {
            if (cachedTechs == null)
            {
                var json = RequestBuilder.GetTechniques();
                cachedTechs = JsonConvert.DeserializeObject<List<MeleeTechnique>>(json);
            }
            return cachedTechs.FirstOrDefault(x => x.TechName.ToLower().Replace(" ", "").Normalize().Contains(name.ToLower().Replace(" ", "").Normalize()));
        }
    }
}
