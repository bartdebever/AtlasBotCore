using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchHandler.DataTypes
{
    public class OverwatchAbility
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool is_ultimate { get; set; }
    }
}
