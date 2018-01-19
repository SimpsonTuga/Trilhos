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
    public class Guides2Controller : Controller
    {
        private readonly Trails4HealthDbContext _context;

        public Guides2Controller(Trails4HealthDbContext context)
        {
            _context = context;    
        }

        // GET: Guides2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Guide.ToListAsync());
        }

        // GET: Guides2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guide = await _context.Guide
                .SingleOrDefaultAsync(m => m.GuideId == id);
            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // GET: Guides2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guides2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuideId,Name,Phone,Email,NIF")] Guide guide)
        {

            /*
            int ÑIF = Guide.NIF % 10;

            int Controldigit = DigitControl(guide.NIF);

            if (lastDigitNIF != Controldigit)
            {
                ViewData["ErroDigitoControlo"] = "*NIF inválido!";
                return View(guide);
            }
            */

            if (ModelState.IsValid)
            {
                _context.Add(guide);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(guide);
        }

        // GET: Guides2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guide = await _context.Guide.SingleOrDefaultAsync(m => m.GuideId == id);
            if (guide == null)
            {
                return NotFound();
            }
            return View(guide);
        }

        // POST: Guides2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuideId,Name,Phone,Email,NIF")] Guide guide)
        {
            if (id != guide.GuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideExists(guide.GuideId))
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
            return View(guide);
        }

        // GET: Guides2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guide = await _context.Guide
                .SingleOrDefaultAsync(m => m.GuideId == id);
            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // POST: Guides2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guide = await _context.Guide.SingleOrDefaultAsync(m => m.GuideId == id);
            _context.Guide.Remove(guide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GuideExists(int id)
        {
            return _context.Guide.Any(e => e.GuideId == id);
        }

        private int DigitControl(int NIF)
        {
            int digit;
            int[] arrDigits = new int[8];
            int add = 0;
            int n = 2;
            int rest;
            int controldigit;

            for (int i = 0; i < 8; i++)
            {
                NIF /= 10;
                digit = NIF % 10; 
                arrDigits[i] = digit;

                add += arrDigits[i] * n;
                n++;
            }

            rest = add % 11;

            if (rest == 1 || rest == 0 )
            {
                controldigit = 0;
            }
            else
            {
                controldigit = 11 - rest;
            }
            return controldigit;
        }

    }
}
