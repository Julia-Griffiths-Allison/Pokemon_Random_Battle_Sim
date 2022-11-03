using Microsoft.AspNetCore.Mvc;
using Pokemon_Random_Battle_Sim.Interfaces;

namespace Pokemon_Random_Battle_Sim.Controllers
{
    public class AdventureController : Controller
    {
        private readonly IAdventureRepo _repo;
        public AdventureController(IAdventureRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            _repo.CreateNPCTeam();
            return View();
        }
        public IActionResult SingleBattle()
        {
            var encounter = _repo.DisplayEncounter();
            return View(encounter);
        }
        public IActionResult TeamBattle()
        {
            var battle = _repo.DisplayNewTeam();
            return View(battle);
        }
    }
}
