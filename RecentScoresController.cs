using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment3.Data;
using assignment3.Models;

namespace assignment3.Controllers
{
    public class RecentScoresController : Controller
    {
        private readonly HASCContext _context;

        public RecentScoresController(HASCContext context)
        {
            _context = context;
        }

        // GET: RecentScores
        public async Task<IActionResult> Index()
        {
            var rScores = (from r in _context.Games                        
                            orderby r.GameDate descending
                          where r.HomeTeamScore != null                           
                          select r ).Take(10);

            return View(await rScores.Include(r => r.HomeTeam).Include(r => r.AwayTeam).AsNoTracking().ToListAsync());
        }

       

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
