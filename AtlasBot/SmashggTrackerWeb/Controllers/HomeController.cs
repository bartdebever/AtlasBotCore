using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmashggTracker.DAL;
using SmashggTrackerWeb.Models;
using RestSharp;
using SmashggTrackerWeb.Models.HeadToHead;

namespace SmashggTrackerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HeadToHead()
        {
            var dbContext = new SmashggTrackerContext();
            int user1 = 549;
            int user2 = 544;
            var player1 = dbContext.Players.FirstOrDefault(x => x.Id == user1);
            var player2 = dbContext.Players.FirstOrDefault(x => x.Id == user2);
            var matches = dbContext.Matches
                .Where(x => (x.Player1.Id == user1 || x.Player2.Id == user1) &&
                            (x.Player2.Id == user2 || x.Player1.Id == user2)).Include(x => x.Player1)
                .Include(x => x.Player2).Include(x => x.Matches).Include(x=>x.Tournament).ToList();
            ViewBag.Player1 = player1.Name;
            ViewBag.Player2 = player2.Name;
            var stageMatchupP1 = new StageMatchup();
            var characterStatsP1 = new StageMatchup();
            var characterStatsP2 = new StageMatchup();
            foreach (var match in matches)
            {
                foreach (var game in match.Matches)
                {
                    if (match.Player1.Id == user1)
                    {
                        if (game.StocksP1 > game.StocksP2)
                        {
                            if(!string.IsNullOrEmpty(StageConverter.GetStageById(game.StageId)))
                                stageMatchupP1.AddStageWin(game.StageId);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP1 - 1)))
                                characterStatsP1.AddStageWin(game.CharacterIdP1);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP2 - 1)))
                                characterStatsP2.AddStageLoss(game.CharacterIdP2);
                        }
                        else
                        {
                            if(!string.IsNullOrEmpty(StageConverter.GetStageById(game.StageId)))
                                stageMatchupP1.AddStageLoss(game.StageId);
                            if(!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP1-1)))
                                characterStatsP1.AddStageLoss(game.CharacterIdP1);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP2 - 1)))
                                characterStatsP2.AddStageWin(game.CharacterIdP2);
                        }
                    }
                    else if(!string.IsNullOrEmpty(StageConverter.GetStageById(game.StageId)))
                    {
                        if (game.StocksP1 > game.StocksP2)
                        {
                            if (!string.IsNullOrEmpty(StageConverter.GetStageById(game.StageId)))
                                stageMatchupP1.AddStageLoss(game.StageId);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP1 - 1)))
                                characterStatsP1.AddStageLoss(game.CharacterIdP1);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP2 - 1)))
                                characterStatsP2.AddStageWin(game.CharacterIdP2);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(StageConverter.GetStageById(game.StageId)))
                                stageMatchupP1.AddStageWin(game.StageId);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP1 - 1)))
                                characterStatsP1.AddStageWin(game.CharacterIdP1);
                            if (!string.IsNullOrEmpty(CharacterConverter.GetChracterById(game.CharacterIdP2 - 1)))
                                characterStatsP2.AddStageLoss(game.CharacterIdP2);
                        }
                    }

                }
            }
            ViewBag.StagesP1 = stageMatchupP1;
            ViewBag.CharacterP1 = characterStatsP1;
            ViewBag.CharacterP2 = characterStatsP2;
            return View(matches);
        }

        [HttpGet]
        public IActionResult GetPlayerStats(int id)
        {
            var restClient = new RestClient("http://api.smash.gg/");
            var restRequest = new RestRequest("player/" + id.ToString());
            var response = restClient.ExecuteAsGet(restRequest, "GET");
            var content = response.Content;
            return Ok(content);
        }
    }
}
