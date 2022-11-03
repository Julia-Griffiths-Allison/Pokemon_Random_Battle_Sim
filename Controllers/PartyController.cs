using Microsoft.AspNetCore.Mvc;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using Pokemon_Random_Battle_Sim.Repos;

namespace Pokemon_Random_Battle_Sim.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyRepo _repo;
        public PartyController(IPartyRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var party = _repo.DisplayNewTeam();
            return View(party);
        }
        public IActionResult ManageParty()
        {
            _repo.CreateTeam();
            return RedirectToAction("Index");
        }
    }
}
