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
    public class PojistenecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PojistenecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojistenecs
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userWithInsurance =  _context.Pojistenec.Include(u => u.MojePojisteni).ToList();
            return View(userWithInsurance);
        }

        // GET: Pojistenecs/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec.Include(a => a.MojePojisteni)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojistenec == null)
            {
                return NotFound();
            }

            return View(pojistenec);
        }

        // GET: Pojistenecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pojistenecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni,Email,TelCislo,UliceCisloPop,Mesto,Psc")] Pojistenec pojistenec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojistenec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pojistenec);
        }

        // GET: Pojistenecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec.FindAsync(id);
            if (pojistenec == null)
            {
                return NotFound();
            }
            return View(pojistenec);
        }

        // POST: Pojistenecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni,Email,TelCislo,UliceCisloPop,Mesto,Psc")] Pojistenec pojistenec)
        {
            if (id != pojistenec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojistenec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojistenecExists(pojistenec.Id))
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
            return View(pojistenec);
        }

        // GET: Pojistenecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojistenec == null)
            {
                return NotFound();
            }

            return View(pojistenec);
        }

        // POST: Pojistenecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojistenec == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojistenec'  is null.");
            }
            var pojistenec = await _context.Pojistenec.FindAsync(id);
            if (pojistenec != null)
            {
                _context.Pojistenec.Remove(pojistenec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojistenecExists(int id)
        {
          return (_context.Pojistenec?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
