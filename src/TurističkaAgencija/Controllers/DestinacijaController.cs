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
    public class DestinacijaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public DestinacijaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = _context.Destinacija.Include(d => d.Drzava);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        public async Task<IActionResult> List()
        {
            var turistickaAgencijaContext = _context.Destinacija.Include(d => d.Drzava);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        public IActionResult Search (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var rezultat = _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj)
                .Where(p => p.DestinacijaId == id)
                .ToList();

            ViewBag.Grad = _context.Destinacija.Where(d => d.Id == id).Select(d => d.Grad).FirstOrDefault();

            Home home = new Home
            {
                Ponuda = rezultat
            };
            return View(home);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["DrzavaId"] = new SelectList(_context.Drzava, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DrzavaId,Grad,Opis,Slika")] Destinacija destinacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinacija);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            ViewData["DrzavaId"] = new SelectList(_context.Drzava, "Id", "Naziv", destinacija.DrzavaId);
            return View(destinacija);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinacija = await _context.Destinacija.FindAsync(id);
            if (destinacija == null)
            {
                return NotFound();
            }
            ViewData["DrzavaId"] = new SelectList(_context.Drzava, "Id", "Naziv", destinacija.DrzavaId);
            return View(destinacija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DrzavaId,Grad,Opis,Slika")] Destinacija destinacija)
        {
            if (id != destinacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinacijaExists(destinacija.Id))
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
            ViewData["DrzavaId"] = new SelectList(_context.Drzava, "Id", "Naziv", destinacija.DrzavaId);
            return View(destinacija);
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var destinacija = await _context.Destinacija.FindAsync(id).ConfigureAwait(false);

            _context.Destinacija.Remove(destinacija);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("List", "Destinacija");
        }

        private bool DestinacijaExists(int id)
        {
            return _context.Destinacija.Any(e => e.Id == id);
        }
    }
}
