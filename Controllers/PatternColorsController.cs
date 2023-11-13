using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D424.Data;
using D424.Models;

namespace D424.Controllers
{
    public class PatternColorsController : Controller
    {
        private readonly D424Context _context;

        public PatternColorsController(D424Context context)
        {
            _context = context;
        }

        // GET: PatternColors
        public async Task<IActionResult> Index()
        {
              return _context.PatternColor != null ? 
                          View(await _context.PatternColor.ToListAsync()) :
                          Problem("Entity set 'D424Context.PatternColor'  is null.");
        }

        // GET: PatternColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatternColor == null)
            {
                return NotFound();
            }

            var patternColor = await _context.PatternColor
                .FirstOrDefaultAsync(m => m.PatternID == id);
            if (patternColor == null)
            {
                return NotFound();
            }

            return View(patternColor);
        }

        // GET: PatternColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatternColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatternID,FlossID")] PatternColor patternColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patternColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patternColor);
        }

        // GET: PatternColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatternColor == null)
            {
                return NotFound();
            }

            var patternColor = await _context.PatternColor.FindAsync(id);
            if (patternColor == null)
            {
                return NotFound();
            }
            return View(patternColor);
        }

        // POST: PatternColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatternID,FlossID")] PatternColor patternColor)
        {
            if (id != patternColor.PatternID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patternColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatternColorExists(patternColor.PatternID))
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
            return View(patternColor);
        }

        // GET: PatternColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatternColor == null)
            {
                return NotFound();
            }

            var patternColor = await _context.PatternColor
                .FirstOrDefaultAsync(m => m.PatternID == id);
            if (patternColor == null)
            {
                return NotFound();
            }

            return View(patternColor);
        }

        // POST: PatternColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatternColor == null)
            {
                return Problem("Entity set 'D424Context.PatternColor'  is null.");
            }
            var patternColor = await _context.PatternColor.FindAsync(id);
            if (patternColor != null)
            {
                _context.PatternColor.Remove(patternColor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatternColorExists(int id)
        {
          return (_context.PatternColor?.Any(e => e.PatternID == id)).GetValueOrDefault();
        }
    }
}
