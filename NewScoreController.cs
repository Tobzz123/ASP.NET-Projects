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
    public class NewScoreController : Controller
    {
        private readonly HASCContext _context;

        public NewScoreController(HASCContext context)
        {
            _context = context;
        }

        // GET: NewScore
        public async Task<IActionResult> Index(string refereeId)
        {
            var refereeNames = from r in _context.Referees
                               orderby r.LastName
                               select new { Name = r.FirstName + " " + r.LastName, r.RefereeId };

            ViewBag.RefereeId = new SelectList(refereeNames, "RefereeId", "Name");
            var referees = from a in _context.Games
                            .Include(a => a.Referee)
                        .Where(a => a.HomeTeamScore == null)
                        .OrderBy(a => a.Referee.LastName)
                        .ThenBy(a => a.Referee.FirstName)
                           select a; 
           

            if (!string.IsNullOrEmpty(refereeId))
            {
                referees = referees.Where(a => a.RefereeId.ToString() == refereeId);
            }
            return View(await referees.Include(a=> a.HomeTeam).Include(a => a.AwayTeam).AsNoTracking().ToListAsync());
        }

     
        // GET: NewScore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId", game.RefereeId);
            return View(game);
        }

        // POST: NewScore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,GameDate,Field,HomeTeamId,HomeTeamScore,AwayTeamId,AwayTeamScore,RefereeId,GameNotes")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId", game.RefereeId);
            return View(game);
        }

       
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
