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
    public class NeedlesController : Controller
    {
        private readonly D424Context _context;

        public NeedlesController(D424Context context)
        {
            _context = context;
        }

        // GET: Needles
        public async Task<IActionResult> Index()
        {
              return _context.Needle != null ? 
                          View(await _context.Needle.ToListAsync()) :
                          Problem("Entity set 'D424Context.Needle'  is null.");
        }

        // GET: Needles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Needle == null)
            {
                return NotFound();
            }

            var needle = await _context.Needle
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (needle == null)
            {
                return NotFound();
            }

            return View(needle);
        }

        // GET: Needles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Needles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeedleSize,SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Needle needle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(needle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(needle);
        }

        // GET: Needles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Needle == null)
            {
                return NotFound();
            }

            var needle = await _context.Needle.FindAsync(id);
            if (needle == null)
            {
                return NotFound();
            }
            return View(needle);
        }

        // POST: Needles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NeedleSize,SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Needle needle)
        {
            if (id != needle.SupplyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(needle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeedleExists(needle.SupplyID))
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
            return View(needle);
        }

        // GET: Needles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Needle == null)
            {
                return NotFound();
            }

            var needle = await _context.Needle
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (needle == null)
            {
                return NotFound();
            }

            return View(needle);
        }

        // POST: Needles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Needle == null)
            {
                return Problem("Entity set 'D424Context.Needle'  is null.");
            }
            var needle = await _context.Needle.FindAsync(id);
            if (needle != null)
            {
                _context.Needle.Remove(needle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeedleExists(int id)
        {
          return (_context.Needle?.Any(e => e.SupplyID == id)).GetValueOrDefault();
        }
    }
}
