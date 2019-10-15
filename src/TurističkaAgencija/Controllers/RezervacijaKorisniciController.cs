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
    public class RezervacijaKorisniciController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public RezervacijaKorisniciController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = _context.RezervacijaKorisnici
                .Include(r => r.Korisnik)
                .Include(r => r.Rezervacija)
                .Include(r => r.Rezervacija.Ponuda);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacijaKorisnici = await _context.RezervacijaKorisnici
                .Include(r => r.Korisnik)
                .Include(r => r.Rezervacija)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacijaKorisnici == null)
            {
                return NotFound();
            }

            return View(rezervacijaKorisnici);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime");
            ViewData["RezervacijaId"] = new SelectList(_context.Rezervacija, "Id", "Id");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervacijaId,KorisnikId,DatumRezervacije")] RezervacijaKorisnici rezervacijaKorisnici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacijaKorisnici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacijaKorisnici.KorisnikId);
            ViewData["RezervacijaId"] = new SelectList(_context.Rezervacija, "Id", "Id", rezervacijaKorisnici.RezervacijaId);
            return View(rezervacijaKorisnici);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacijaKorisnici = await _context.RezervacijaKorisnici.FindAsync(id);
            if (rezervacijaKorisnici == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacijaKorisnici.KorisnikId);
            ViewData["RezervacijaId"] = new SelectList(_context.Rezervacija, "Id", "Id", rezervacijaKorisnici.RezervacijaId);
            return View(rezervacijaKorisnici);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervacijaId,KorisnikId,DatumRezervacije")] RezervacijaKorisnici rezervacijaKorisnici)
        {
            if (id != rezervacijaKorisnici.RezervacijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacijaKorisnici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaKorisniciExists(rezervacijaKorisnici.RezervacijaId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacijaKorisnici.KorisnikId);
            ViewData["RezervacijaId"] = new SelectList(_context.Rezervacija, "Id", "Id", rezervacijaKorisnici.RezervacijaId);
            return View(rezervacijaKorisnici);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacijaKorisnici = await _context.RezervacijaKorisnici
                .Include(r => r.Korisnik)
                .Include(r => r.Rezervacija)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacijaKorisnici == null)
            {
                return NotFound();
            }

            return View(rezervacijaKorisnici);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacijaKorisnici = await _context.RezervacijaKorisnici.FindAsync(id);
            _context.RezervacijaKorisnici.Remove(rezervacijaKorisnici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaKorisniciExists(int id)
        {
            return _context.RezervacijaKorisnici.Any(e => e.RezervacijaId == id);
        }
    }
}
