using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmashggTracker;
using SmashggTracker.DAL;
using SmashggTracker.Models;
using SmashGgHandler;
using Player = SmashGgHandler.Player;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
//            foreach (var dutchTournament in RequestHandler.GetDutchTournaments().items.entities.tournament)
//            {
//                Console.WriteLine(dutchTournament.name);
//                try
//                {
//                    var tournament = RequestHandler.GetTournamentRoot(dutchTournament.shortSlug);
//                    var bracketId = 0;
//                    foreach (var @event in tournament.entities.Event)
//                    {
//                        if (@event.videogameId == 1 && @event.entrantSizeMax != null && @event.entrantSizeMax == 1)
//                        {
//                            bracketId = @event.id;
//                        }
//                    }
//                    if (bracketId == 0)
//                        break;
//                    var phases = tournament.entities.phase.Where(x => x.eventId == Convert.ToInt32(bracketId));
//                    var results = new List<Set>();
//                    var players = new List<Player>();
//                    foreach (var phase in phases)
//                    {
//                        var @group = tournament.entities.groups.FirstOrDefault(x => x.phaseId == phase.id);
//                        var result = RequestHandler.GetResultSets(@group.id);
//                        if (result?.Entities?.Sets != null)
//                        {
//                            results.AddRange(result.Entities.Sets);
//                            players.AddRange(result.Entities.Player);
//                        }
//
//                    }
//                    Console.WriteLine(results.Count);
//                    SmashggConverter.ConvertTournament(tournament.entities.tournament, tournament.entities.Event, results, players, new SmashggTracker.Models.Game());
//                    Console.WriteLine("Success");
//                }
//                catch(Exception e)
//                {
//                    Console.WriteLine("Failed");
//                    Console.WriteLine(e.Message);
//                }
//
//            }
            Console.WriteLine("Enter a tournament name");
            var tournamentId = Console.ReadLine();
            var tournament = RequestHandler.GetTournamentRoot(tournamentId);
            foreach (var gameEvent in tournament.entities.Event)
            {
            var game = tournament.entities.videogame.FirstOrDefault(x => x.id == gameEvent.videogameId);
            Console.WriteLine(game.name + " " + gameEvent.name + ": " + gameEvent.id);
            }
            Console.WriteLine("Enter the event Id");
            var bracketId = Console.ReadLine();
            var phases = tournament.entities.phase.Where(x => x.eventId == Convert.ToInt32(bracketId));
            var results = new List<Set>();
            var players = new List<Player>();
            foreach (var phase in phases)
            {
                var @group = tournament.entities.groups.FirstOrDefault(x => x.phaseId == phase.id);
                var result = RequestHandler.GetResultSets(@group.id);
                if (result?.Entities?.Sets != null)
                {
                    results.AddRange(result.Entities.Sets);
                    players.AddRange(result.Entities.Player);
                }

            }
            Console.WriteLine(results.Count);
            SmashggConverter.ConvertTournament(tournament.entities.tournament, tournament.entities.Event, results, players, new SmashggTracker.Models.Game());
            Console.WriteLine("Success");
            //            var dbContext = new SmashggTrackerContext();
            //            Console.WriteLine("Select player one");
            //            var player1 = Console.ReadLine();
            //            Console.WriteLine("Select player two");
            //            var player2 = Console.ReadLine();
            //            var games = dbContext.Matches.Where(x =>
            //                (x.Player1.Name == player1 || x.Player2.Name == player1) &&
            //                (x.Player1.Name == player2 || x.Player2.Name == player2)).Include(x=> x.Player1).Include(x=>x.Player2).Include(x=>x.Tournament);
            //            foreach (var match in games)
            //            {
            //                Console.WriteLine($"{match.Player1.Name} vs {match.Player2.Name}: {match.Score1} - {match.Score2} at {match.Tournament.Name}");
            //            }
            Console.ReadLine();
        }
    }
}

