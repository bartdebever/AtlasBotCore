using System;
using System.Collections.Generic;
using System.Text;

namespace SmashggTracker.Models
{
    public class GameMatch
    {
        public int Id { get; set; }
        public int StocksP1 { get; set; }
        public int StocksP2 { get; set; }
        public int CharacterIdP1 { get; set; }
        public int CharacterIdP2 { get; set; }
        public int StageId { get; set; }
    }
}
