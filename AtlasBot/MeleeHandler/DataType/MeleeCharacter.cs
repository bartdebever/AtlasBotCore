using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeleeHandler.DataType;

namespace MeleeHandler
{
    public class MeleeCharacter
    {
        public int id { get; set; }
        public string name { get; set; }
        public int tierdata { get; set; }
        public string weight { get; set; }
        public string fallspeed { get; set; }
        public string walljump { get; set; }
        public string guide { get; set; }
        public int game { get; set; }
        public List<SmashLoungeGif> gifs { get; set; }
    }
}
