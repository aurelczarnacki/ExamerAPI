using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamerAPI.Data;
using ExamerAPI.Models;

namespace ExamerAPI.Controllers
{
    public class TempsController : Controller
    {
        private readonly ExamerContext _context;

        public TempsController(ExamerContext context)
        {
            _context = context;
        }

        // GET: Temps
        public async Task<IActionResult> Index()
        {
              return _context.Temp != null ? 
                          View(await _context.Temp.ToListAsync()) :
                          Problem("Entity set 'ExamerContext.Temp'  is null.");
        }

        // GET: Temps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Temp == null)
            {
                return NotFound();
            }

            var temp = await _context.Temp
                .FirstOrDefaultAsync(m => m.id == id);
            if (temp == null)
            {
                return NotFound();
            }

            return View(temp);
        }

        // GET: Temps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Temp temp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temp);
        }

        // GET: Temps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Temp == null)
            {
                return NotFound();
            }

            var temp = await _context.Temp.FindAsync(id);
            if (temp == null)
            {
                return NotFound();
            }
            return View(temp);
        }

        // POST: Temps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Temp temp)
        {
            if (id != temp.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempExists(temp.id))
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
            return View(temp);
        }

        // GET: Temps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Temp == null)
            {
                return NotFound();
            }

            var temp = await _context.Temp
                .FirstOrDefaultAsync(m => m.id == id);
            if (temp == null)
            {
                return NotFound();
            }

            return View(temp);
        }

        // POST: Temps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Temp == null)
            {
                return Problem("Entity set 'ExamerContext.Temp'  is null.");
            }
            var temp = await _context.Temp.FindAsync(id);
            if (temp != null)
            {
                _context.Temp.Remove(temp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempExists(int id)
        {
          return (_context.Temp?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
