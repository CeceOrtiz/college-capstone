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
    public class SuppliesController : Controller
    {
        private readonly D424Context _context;

        public SuppliesController(D424Context context)
        {
            _context = context;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
              return _context.Supply != null ? 
                          View(await _context.Supply.ToListAsync()) :
                          Problem("Entity set 'D424Context.Supply'  is null.");
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Supply supply)
        {
            if (id != supply.SupplyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.SupplyID))
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
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supply == null)
            {
                return NotFound();
            }

            var supply = await _context.Supply
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supply == null)
            {
                return Problem("Entity set 'D424Context.Supply'  is null.");
            }
            var supply = await _context.Supply.FindAsync(id);
            if (supply != null)
            {
                _context.Supply.Remove(supply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
          return (_context.Supply?.Any(e => e.SupplyID == id)).GetValueOrDefault();
        }
    }
}
