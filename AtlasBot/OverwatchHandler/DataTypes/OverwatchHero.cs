using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchHandler.DataTypes
{
    public class OverwatchHero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int health { get; set; }
        public int armor { get; set; }
        public int shield { get; set; }
        public string real_name { get; set; }
        public int? age { get; set;}
        public int? height { get; set; }
        public string affiliation { get; set; }
        public string base_of_operations { get; set; }
        public int difficulty { get; set; }
        public OverwatchRole role { get; set; }
        public List<OverwatchRole> sub_roles { get; set; }
        public List<OverwatchAbility> abilities { get; set; }
    }

    public class OverwatchRole
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
