using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurističkaAgencija.Models;

namespace TurističkaAgencija.Controllers
{
    public class TipPrevozaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public TipPrevozaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: TipPrevozas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipPrevoza.ToListAsync());
        }

        // GET: TipPrevozas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPrevoza = await _context.TipPrevoza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipPrevoza == null)
            {
                return NotFound();
            }

            return View(tipPrevoza);
        }

        // GET: TipPrevozas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipPrevozas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] TipPrevoza tipPrevoza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipPrevoza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipPrevoza);
        }

        // GET: TipPrevozas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPrevoza = await _context.TipPrevoza.FindAsync(id);
            if (tipPrevoza == null)
            {
                return NotFound();
            }
            return View(tipPrevoza);
        }

        // POST: TipPrevozas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] TipPrevoza tipPrevoza)
        {
            if (id != tipPrevoza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipPrevoza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipPrevozaExists(tipPrevoza.Id))
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
            return View(tipPrevoza);
        }

        // GET: TipPrevozas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipPrevoza = await _context.TipPrevoza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipPrevoza == null)
            {
                return NotFound();
            }

            return View(tipPrevoza);
        }

        // POST: TipPrevozas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipPrevoza = await _context.TipPrevoza.FindAsync(id);
            _context.TipPrevoza.Remove(tipPrevoza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipPrevozaExists(int id)
        {
            return _context.TipPrevoza.Any(e => e.Id == id);
        }
    }
}
