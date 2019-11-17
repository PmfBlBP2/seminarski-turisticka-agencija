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
    public class SmjestajController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public SmjestajController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: Smjestaj
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

        // GET: Smjestaj/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestaj = await _context.Smjestaj
                .Include(s => s.Destinacija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smjestaj == null)
            {
                return NotFound();
            }

            return View(smjestaj);
        }

        // GET: Smjestaj/Create
        public IActionResult Create()
        {
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad");
            return View();
        }

        // POST: Smjestaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DestinacijaId,Naziv,Opis,Adresa,Slika")] Smjestaj smjestaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smjestaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", smjestaj.DestinacijaId);
            return View(smjestaj);
        }

        // GET: Smjestaj/Edit/5
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

        // POST: Smjestaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", smjestaj.DestinacijaId);
            return View(smjestaj);
        }

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
