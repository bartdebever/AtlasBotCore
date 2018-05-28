using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotWrapper.Services;

namespace RiotWrapper
{
    public class RiotClient
    {
        public SummonerService Summoner { get; set; }
        public LeagueService League { get; set; }
        public MasteryService Masteries { get; set; }
        public SpecateService Specate { get; set; }
        public RiotClient(string apiKey)
        {
            Summoner = new SummonerService(apiKey);
            League = new LeagueService(apiKey);
            Masteries = new MasteryService(apiKey);
            Specate = new SpecateService(apiKey);
        }
    }
}
