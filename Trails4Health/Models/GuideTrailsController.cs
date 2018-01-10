using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Data;

namespace Trails4Health.Models
{
    public class GuideTrailsController : Controller
    {
        private readonly Trails4HealthDbContext _context;

        public GuideTrailsController(Trails4HealthDbContext context)
        {
            _context = context;    
        }

        // GET: GuideTrails
        public async Task<IActionResult> Index()
        {
            var trails4HealthDbContext = _context.GuideTrail.Include(g => g.Guide).Include(g => g.Trail);
            return View(await trails4HealthDbContext.ToListAsync());
        }

        // GET: GuideTrails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideTrail = await _context.GuideTrail
                .Include(g => g.Guide)
                .Include(g => g.Trail)
                .SingleOrDefaultAsync(m => m.GuideId == id);
            if (guideTrail == null)
            {
                return NotFound();
            }

            return View(guideTrail);
        }

        // GET: GuideTrails/Create
        public IActionResult Create()
        {
            ViewData["GuideId"] = new SelectList(_context.Guide, "GuideId", "Email");
            ViewData["TrailId"] = new SelectList(_context.Trail, "DifficultyId", "DifficultyId");
            return View();
        }

        // POST: GuideTrails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailId,GuideId")] GuideTrail guideTrail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guideTrail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GuideId"] = new SelectList(_context.Guide, "GuideId", "Email", guideTrail.GuideId);
            ViewData["TrailId"] = new SelectList(_context.Trail, "DifficultyId", "DifficultyId", guideTrail.TrailId);
            return View(guideTrail);
        }

        // GET: GuideTrails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideTrail = await _context.GuideTrail.SingleOrDefaultAsync(m => m.GuideId == id);
            if (guideTrail == null)
            {
                return NotFound();
            }
            ViewData["GuideId"] = new SelectList(_context.Guide, "GuideId", "Email", guideTrail.GuideId);
            ViewData["TrailId"] = new SelectList(_context.Trail, "DifficultyId", "DifficultyId", guideTrail.TrailId);
            return View(guideTrail);
        }

        // POST: GuideTrails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailId,GuideId")] GuideTrail guideTrail)
        {
            if (id != guideTrail.GuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guideTrail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideTrailExists(guideTrail.GuideId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["GuideId"] = new SelectList(_context.Guide, "GuideId", "Email", guideTrail.GuideId);
            ViewData["TrailId"] = new SelectList(_context.Trail, "DifficultyId", "DifficultyId", guideTrail.TrailId);
            return View(guideTrail);
        }

        // GET: GuideTrails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideTrail = await _context.GuideTrail
                .Include(g => g.Guide)
                .Include(g => g.Trail)
                .SingleOrDefaultAsync(m => m.GuideId == id);
            if (guideTrail == null)
            {
                return NotFound();
            }

            return View(guideTrail);
        }

        // POST: GuideTrails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guideTrail = await _context.GuideTrail.SingleOrDefaultAsync(m => m.GuideId == id);
            _context.GuideTrail.Remove(guideTrail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GuideTrailExists(int id)
        {
            return _context.GuideTrail.Any(e => e.GuideId == id);
        }
    }
}
