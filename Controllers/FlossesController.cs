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
    public class FlossesController : Controller
    {
        private readonly D424Context _context;

        public FlossesController(D424Context context)
        {
            _context = context;
        }

        // GET: Flosses
        public async Task<IActionResult> Index()
        {
              return _context.Floss != null ? 
                          View(await _context.Floss.ToListAsync()) :
                          Problem("Entity set 'D424Context.Floss'  is null.");
        }

        // GET: Flosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Floss == null)
            {
                return NotFound();
            }

            var floss = await _context.Floss
                .FirstOrDefaultAsync(m => m.FlossID == id);
            if (floss == null)
            {
                return NotFound();
            }

            return View(floss);
        }

        // GET: Flosses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlossID")] Floss floss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(floss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(floss);
        }

        // GET: Flosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Floss == null)
            {
                return NotFound();
            }

            var floss = await _context.Floss.FindAsync(id);
            if (floss == null)
            {
                return NotFound();
            }
            return View(floss);
        }

        // POST: Flosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlossID")] Floss floss)
        {
            if (id != floss.FlossID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(floss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlossExists(floss.FlossID))
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
            return View(floss);
        }

        // GET: Flosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Floss == null)
            {
                return NotFound();
            }

            var floss = await _context.Floss
                .FirstOrDefaultAsync(m => m.FlossID == id);
            if (floss == null)
            {
                return NotFound();
            }

            return View(floss);
        }

        // POST: Flosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Floss == null)
            {
                return Problem("Entity set 'D424Context.Floss'  is null.");
            }
            var floss = await _context.Floss.FindAsync(id);
            if (floss != null)
            {
                _context.Floss.Remove(floss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlossExists(int id)
        {
          return (_context.Floss?.Any(e => e.FlossID == id)).GetValueOrDefault();
        }
    }
}
