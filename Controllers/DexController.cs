using Microsoft.AspNetCore.Mvc;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using Pokemon_Random_Battle_Sim.Repos;
using System.Data;

namespace Pokemon_Random_Battle_Sim.Controllers
{
    public class DexController : Controller
    {
        private readonly IDexRepo repo;
        public DexController(IDexRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var dex = repo.GetDex();
            return View(dex);
        }
    }
}
