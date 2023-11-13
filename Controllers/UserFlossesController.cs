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
    public class UserFlossesController : Controller
    {
        private readonly D424Context _context;

        public UserFlossesController(D424Context context)
        {
            _context = context;
        }

        // GET: UserFlosses
        public async Task<IActionResult> Index()
        {
              return _context.UserFloss != null ? 
                          View(await _context.UserFloss.ToListAsync()) :
                          Problem("Entity set 'D424Context.UserFloss'  is null.");
        }

        // GET: UserFlosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserFloss == null)
            {
                return NotFound();
            }

            var userFloss = await _context.UserFloss
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userFloss == null)
            {
                return NotFound();
            }

            return View(userFloss);
        }

        // GET: UserFlosses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFlosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FlossID,Quantity,Storage")] UserFloss userFloss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFloss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFloss);
        }

        // GET: UserFlosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserFloss == null)
            {
                return NotFound();
            }

            var userFloss = await _context.UserFloss.FindAsync(id);
            if (userFloss == null)
            {
                return NotFound();
            }
            return View(userFloss);
        }

        // POST: UserFlosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FlossID,Quantity,Storage")] UserFloss userFloss)
        {
            if (id != userFloss.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFloss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFlossExists(userFloss.UserID))
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
            return View(userFloss);
        }

        // GET: UserFlosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserFloss == null)
            {
                return NotFound();
            }

            var userFloss = await _context.UserFloss
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userFloss == null)
            {
                return NotFound();
            }

            return View(userFloss);
        }

        // POST: UserFlosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserFloss == null)
            {
                return Problem("Entity set 'D424Context.UserFloss'  is null.");
            }
            var userFloss = await _context.UserFloss.FindAsync(id);
            if (userFloss != null)
            {
                _context.UserFloss.Remove(userFloss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFlossExists(int id)
        {
          return (_context.UserFloss?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
    }
}
