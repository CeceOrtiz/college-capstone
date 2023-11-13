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
    public class FabricsController : Controller
    {
        private readonly D424Context _context;

        public FabricsController(D424Context context)
        {
            _context = context;
        }

        // GET: Fabrics
        public async Task<IActionResult> Index()
        {
              return _context.Fabric != null ? 
                          View(await _context.Fabric.ToListAsync()) :
                          Problem("Entity set 'D424Context.Fabric'  is null.");
        }

        // GET: Fabrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fabric == null)
            {
                return NotFound();
            }

            var fabric = await _context.Fabric
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (fabric == null)
            {
                return NotFound();
            }

            return View(fabric);
        }

        // GET: Fabrics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabrics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FabricType,FabricCount,FabricColor,SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Fabric fabric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fabric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabric);
        }

        // GET: Fabrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fabric == null)
            {
                return NotFound();
            }

            var fabric = await _context.Fabric.FindAsync(id);
            if (fabric == null)
            {
                return NotFound();
            }
            return View(fabric);
        }

        // POST: Fabrics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FabricType,FabricCount,FabricColor,SupplyID,ItemName,ItemType,Quantity,Brand,Storage,UserID")] Fabric fabric)
        {
            if (id != fabric.SupplyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fabric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricExists(fabric.SupplyID))
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
            return View(fabric);
        }

        // GET: Fabrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fabric == null)
            {
                return NotFound();
            }

            var fabric = await _context.Fabric
                .FirstOrDefaultAsync(m => m.SupplyID == id);
            if (fabric == null)
            {
                return NotFound();
            }

            return View(fabric);
        }

        // POST: Fabrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fabric == null)
            {
                return Problem("Entity set 'D424Context.Fabric'  is null.");
            }
            var fabric = await _context.Fabric.FindAsync(id);
            if (fabric != null)
            {
                _context.Fabric.Remove(fabric);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricExists(int id)
        {
          return (_context.Fabric?.Any(e => e.SupplyID == id)).GetValueOrDefault();
        }
    }
}
