using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashggTrackerWeb.Models.HeadToHead
{
    public class StageMatchup
    {
        public List<StageStat> Stages { get; set; }
        public void AddStageWin(int id)
        {
            var stage = Stages.FirstOrDefault(x => x.Id == id);
            if (stage != null)
            {
                var index = Stages.IndexOf(stage);
                stage.WinCount++;
                stage.TotalPlayed++;
                Stages.RemoveAt(index);
                Stages.Add(stage);
            }
            else
                Stages.Add(new StageStat(id, true));
        }

        public void AddStageLoss(int id)
        {
            var stage = Stages.FirstOrDefault(x => x.Id == id);
            if (stage != null)
            {
                var index = Stages.IndexOf(stage);
                stage.LostCount++;
                stage.TotalPlayed++;
                Stages.RemoveAt(index);
                Stages.Add(stage);
            }
            else
                Stages.Add(new StageStat(id, false));
        }

        public StageMatchup()
        {
            this.Stages = new List<StageStat>();
        }
    }

    public class StageStat
    {
        public int Id { get; set; }
        public int WinCount { get; set; }
        public int LostCount { get; set; }
        public int TotalPlayed { get; set; }
        public StageStat() { }

        public StageStat(int id, bool won)
        {
            this.Id = id;
            if (won)
            {
                WinCount = 1;
                LostCount = 0;
            }
            else
            {
                WinCount = 0;
                LostCount = 1;
            }
            TotalPlayed = 1;
        }
    }
}
