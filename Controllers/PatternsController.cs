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
    public class PatternsController : Controller
    {
        private readonly D424Context _context;

        public PatternsController(D424Context context)
        {
            _context = context;
        }

        // GET: Patterns
        public async Task<IActionResult> Index()
        {
              return _context.Pattern != null ? 
                          View(await _context.Pattern.ToListAsync()) :
                          Problem("Entity set 'D424Context.Pattern'  is null.");
        }

        // GET: Patterns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pattern == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern
                .FirstOrDefaultAsync(m => m.PatternID == id);
            if (pattern == null)
            {
                return NotFound();
            }

            return View(pattern);
        }

        // GET: Patterns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patterns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatternID,Name,Dimensions,CreatedBy,Source,Location,Status,UserID")] Pattern pattern)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pattern);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pattern);
        }

        // GET: Patterns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pattern == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern.FindAsync(id);
            if (pattern == null)
            {
                return NotFound();
            }
            return View(pattern);
        }

        // POST: Patterns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatternID,Name,Dimensions,CreatedBy,Source,Location,Status,UserID")] Pattern pattern)
        {
            if (id != pattern.PatternID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pattern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatternExists(pattern.PatternID))
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
            return View(pattern);
        }

        // GET: Patterns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pattern == null)
            {
                return NotFound();
            }

            var pattern = await _context.Pattern
                .FirstOrDefaultAsync(m => m.PatternID == id);
            if (pattern == null)
            {
                return NotFound();
            }

            return View(pattern);
        }

        // POST: Patterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pattern == null)
            {
                return Problem("Entity set 'D424Context.Pattern'  is null.");
            }
            var pattern = await _context.Pattern.FindAsync(id);
            if (pattern != null)
            {
                _context.Pattern.Remove(pattern);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatternExists(int id)
        {
          return (_context.Pattern?.Any(e => e.PatternID == id)).GetValueOrDefault();
        }
    }
}
