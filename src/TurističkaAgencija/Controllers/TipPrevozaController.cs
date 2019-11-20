using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipPrevoza.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

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

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var tipPrevoza = await _context.TipPrevoza.FindAsync(id).ConfigureAwait(false);

            _context.TipPrevoza.Remove(tipPrevoza);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "TipPrevoza");
        }

        private bool TipPrevozaExists(int id)
        {
            return _context.TipPrevoza.Any(e => e.Id == id);
        }
    }
}
