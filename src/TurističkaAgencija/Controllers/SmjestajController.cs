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
    public class SmjestajController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public SmjestajController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = _context.Smjestaj.Include(s => s.Destinacija);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        public async Task<IActionResult> List()
        {
            var turistickaAgencijaContext = _context.Smjestaj.Include(s => s.Destinacija);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DestinacijaId,Naziv,Opis,Adresa,Slika")] Smjestaj smjestaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smjestaj);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", smjestaj.DestinacijaId);
            return View(smjestaj);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestaj = await _context.Smjestaj.FindAsync(id);
            if (smjestaj == null)
            {
                return NotFound();
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", smjestaj.DestinacijaId);
            return View(smjestaj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DestinacijaId,Naziv,Opis,Adresa,Slika")] Smjestaj smjestaj)
        {
            if (id != smjestaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smjestaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmjestajExists(smjestaj.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("List");
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", smjestaj.DestinacijaId);
            return View(smjestaj);
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var smjestaj = await _context.Smjestaj.FindAsync(id).ConfigureAwait(false);

            _context.Smjestaj.Remove(smjestaj);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("List", "Smjestaj");
        }

        private bool SmjestajExists(int id)
        {
            return _context.Smjestaj.Any(e => e.Id == id);
        }
    }
}
