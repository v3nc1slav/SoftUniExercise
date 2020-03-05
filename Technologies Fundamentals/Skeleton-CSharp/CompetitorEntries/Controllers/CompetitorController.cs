using CompetitorEntries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompetitorEntries.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly CompetitorEntriesDbContext context;

        public CompetitorController(CompetitorEntriesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Create()
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Create(Competitor competitor)
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            // TODO: Implement me
            return null;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // TODO: Implement me
            return null;
        }

        [HttpPost]
        public IActionResult Delete(Competitor competitor)
        {
            // TODO: Implement me
            return null;
        }
    }
}