using System;
using System.Collections.Generic;

namespace SmashggTracker.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int SmashggId { get; set; }
        public GameEvent Event { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public Tournament Tournament { get; set; }
        public List<GameMatch> Matches { get; set; }
        public string Position { get; set; }
        public DateTime Date { get; set; }
        public Double DateDouble { get; set; }
        public Player Winner
        {
            get
            {
                if (Score1 > Score2)
                    return Player1;
                if (Score2 > Score1)
                    return Player2;
                return null;
            }
        }

        public Game Game { get; set; }

        public Match()
        {
            this.Matches = new List<GameMatch>();
        }
    }
}
