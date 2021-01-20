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
    public class RegisterController : Controller
    {
        private readonly HASCContext _context;

        public RegisterController(HASCContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            var hASCContext = _context.Persons.Include(p => p.Division).Include(p => p.Province).Include(p => p.SkillLevelNavigation).Include(p => p.Team);
            return View(await hASCContext.ToListAsync());
        }

      
        // GET: Register/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionId", "DivisionName");
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId");
            ViewData["SkillLevel"] = new SelectList(_context.Skills, "SkillLevel", "SkillLevel");
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,DivisionId,Email,Gender,BirthDate,AddressLine1,AddressLine2,City,ProvinceId,PostalCode,Phone,Player,SkillLevel,TeamId,JerseyNumber,Coach,CoachingExperience,Referee,RefereeExperience,Administrator,UserPassword")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _context.Add(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionId", "DivisionName");
                ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", person.ProvinceId);
                ViewData["SkillLevel"] = new SelectList(_context.Skills, "SkillLevel", "SkillLevel", person.SkillLevel);
                ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", person.TeamId);


                return View(person);

            }
            catch (Exception ex)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = "0",
                        Description = $"Exception message: {ex.Message}."
                    });

            }
        }
        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
