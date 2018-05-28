using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmashggTracker.DAL;
using SmashggTracker.Models;
using SmashGgHandler;
using Game = SmashggTracker.Models.Game;
using Player = SmashGgHandler.Player;

namespace SmashggTracker
{
   public static class SmashggConverter
    {
        public static void ConvertTournament(SmashGgHandler.Tournament tournamentObject, List<Event> events, List<Set> sets, List<Player> players, Game game)
        {
            var dbContext = new SmashggTrackerContext();
            var tournament = new Models.Tournament
            {
                Name = tournamentObject.name,
                SmashggId = tournamentObject.id
            };
            foreach (var @event in events)
            {
                tournament.Events.Add(new GameEvent
                    {
                        Name = @event.name,
                        SmashggId = @event.id
                    });
            }
            foreach (var player in players)
            {
                var playerObject = dbContext.Players.FirstOrDefault(x => x.SmashggId == (int) player.Id);
                if (playerObject == null)
                {
                    playerObject = new Models.Player
                    {
                        SmashggId = (int) player.Id,
                        Name = player.GamerTag,
                        Sponsor = player.Prefix
                    };
                    dbContext.Players.Add(playerObject);
                }
                    
            }
            foreach (var set in sets)
            {
                var setObject = new Match
                {
                    SmashggId = (int) set.Id,
                    Position = set.FullRoundText,
                    Event = tournament.Events.FirstOrDefault(x => x.SmashggId == (int) set.EventId),
                    Game = game,
                };
                if (set.CompletedAt != null)
                    setObject.DateDouble = (double) set.CompletedAt;
                if (set.Entrant1Score != null)
                    setObject.Score1 = (int) set.Entrant1Score;
                if (set.Entrant2Score != null)
                    setObject.Score2 = (int) set.Entrant2Score;
                
                var player1 = players.FirstOrDefault(x => Convert.ToInt64(x.EntrantId) == set.Entrant1Id);
                if (player1 != null)
                {
                    setObject.Player1 = dbContext.Players.FirstOrDefault(x => x.SmashggId == (int)player1.Id);
                }
                var player2 = players.FirstOrDefault(x => Convert.ToInt64(x.EntrantId) == set.Entrant2Id);
                if (player2 != null)
                {
                    setObject.Player2 = dbContext.Players.FirstOrDefault(x => x.SmashggId == (int)player2.Id);
                }
                foreach (var setGame in set.Games)
                {
                    var gameMatch = new GameMatch();
                    if (setGame.Entrant1P1CharacterId != null)
                        gameMatch.CharacterIdP1 = (int) setGame.Entrant1P1CharacterId;
                    else if (setGame.Selections!=null)
                    {
                        var selection = setGame.Selections[setGame.Entrant1Id.ToString()];
                        var character = selection?["character"];
                        if (character != null)
                            gameMatch.CharacterIdP1 = (int) character[0].SelectionValue;
                    }
                    if (setGame.Entrant2P1CharacterId != null)
                        gameMatch.CharacterIdP2 = (int) setGame.Entrant2P1CharacterId;
                    else if(setGame.Selections != null)
                    {
                        var selection = setGame.Selections[setGame.Entrant2Id.ToString()];
                        var character = selection?["character"];
                        if (character != null)
                            gameMatch.CharacterIdP2 = (int)character[0].SelectionValue;
                    }
                    if (setGame.StageId != null) gameMatch.StageId = (int) setGame.StageId;
                    if (setGame.Entrant1P1Stocks != null) gameMatch.StocksP1 = (int) setGame.Entrant1P1Stocks;
                    if (setGame.Entrant2P1Stocks != null) gameMatch.StocksP2 = (int) setGame.Entrant2P1Stocks;
                    setObject.Matches.Add(gameMatch);
                }

                if (setObject.Player1 != null && setObject.Player2 != null)
                    tournament.Matches.Add(setObject);
            }
            Console.WriteLine("Matches saved: " + tournament.Matches.Count);
            dbContext.Tournaments.Add(tournament);
            dbContext.SaveChanges();
        }
    }
}
