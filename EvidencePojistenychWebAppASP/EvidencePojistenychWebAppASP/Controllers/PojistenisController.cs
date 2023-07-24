using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojistenychWebAppASP.Data;
using EvidencePojistenychWebAppASP.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace EvidencePojistenychWebAppASP.Controllers
{
    [Authorize(Roles = "admin")]
    public class PojistenisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PojistenisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojistenis
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pojisteni.Include(p => p.VlastnikPoj);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pojistenis/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojisteni == null)
            {
                return NotFound();
            }

            var pojisteni = await _context.Pojisteni
                .Include(p => p.VlastnikPoj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni == null)
            {
                return NotFound();
            }

            return View(pojisteni);
        }

        // GET: Pojistenis/Create
        public IActionResult Create()
        {
            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Id");
            return View();
        }

        // POST: Pojistenis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazevPojisteni,CastkaPojisteni,PredmetPojisteni,PlatnostOd,PlatnostDo,PojistenecId")] Pojisteni pojisteni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojisteni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Id", pojisteni.PojistenecId);
            return View(pojisteni);
        }

        // GET: Pojistenis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojisteni == null)
            {
                return NotFound();
            }

            var pojisteni = await _context.Pojisteni.FindAsync(id);
            if (pojisteni == null)
            {
                return NotFound();
            }
            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Id", pojisteni.PojistenecId);
            return View(pojisteni);
        }

        // POST: Pojistenis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazevPojisteni,CastkaPojisteni,PredmetPojisteni,PlatnostOd,PlatnostDo,PojistenecId")] Pojisteni pojisteni)
        {
            if (id != pojisteni.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojisteni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojisteniExists(pojisteni.Id))
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
            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Id", pojisteni.PojistenecId);
            return View(pojisteni);
        }

        // GET: Pojistenis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojisteni == null)
            {
                return NotFound();
            }

            var pojisteni = await _context.Pojisteni
                .Include(p => p.VlastnikPoj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni == null)
            {
                return NotFound();
            }

            return View(pojisteni);
        }

        // POST: Pojistenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojisteni == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojisteni'  is null.");
            }
            var pojisteni = await _context.Pojisteni.FindAsync(id);
            if (pojisteni != null)
            {
                _context.Pojisteni.Remove(pojisteni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojisteniExists(int id)
        {
          return (_context.Pojisteni?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
