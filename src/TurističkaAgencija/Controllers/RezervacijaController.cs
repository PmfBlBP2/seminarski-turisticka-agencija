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
    public class RezervacijaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public RezervacijaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index(int? ponudaId)
        {
            if(ponudaId == null)
            {
                return NotFound();
            }
            var turistickaAgencijaContext = _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.Ponuda)
                .Where(r => r.PonudaId == ponudaId);
            if(turistickaAgencijaContext == null)
            {
                return NotFound();
            }
            return View(await turistickaAgencijaContext.ToListAsync().ConfigureAwait(false));
        }
        public async Task<IActionResult> ExistingUserPartial()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime");
            return PartialView();
        }
        public async Task<IActionResult> NewUserPartial()
        {
            return PartialView();
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.Ponuda)
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create(int? ponudaId)
        {
            if(ponudaId == null)
            {
                return NotFound();
            }
            var rezervacijaContext = _context.Rezervacija
                .Include(k => k.Ponuda)
                .Where(x => x.PonudaId == ponudaId);

            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime");

            return View(rezervacijaContext.FirstOrDefault());
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ponudaId, Rezervacija rezervacija)
        {
            if(rezervacija == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponuda.FindAsync(rezervacija.PonudaId).ConfigureAwait(false);
            if(ponuda == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (rezervacija.Korisnik != null)
                {
                    _context.Add(rezervacija.Korisnik);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    var noviKorisnik = _context.Korisnik
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefault();

                    rezervacija.KorisnikId = noviKorisnik.Id;
                    rezervacija.Iznos = ponuda.Cijena;
                    rezervacija.DatumRezervacije = DateTime.Now;

                    _context.Add(rezervacija);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    rezervacija.Iznos = ponuda.Cijena;
                    rezervacija.DatumRezervacije = DateTime.Now;
                    _context.Add(rezervacija);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacija.KorisnikId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id).ConfigureAwait(false);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacija.KorisnikId);
            ViewData["PonudaId"] = new SelectList(_context.Ponuda, "Id", "Naziv", rezervacija.PonudaId);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PonudaId,KorisnikId,DatumRezervacije,Iznos")] Rezervacija rezervacija)
        {
            if(rezervacija == null)
            {
                return NotFound();
            }
            if (id != rezervacija.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacija.KorisnikId);
            ViewData["PonudaId"] = new SelectList(_context.Ponuda, "Id", "Naziv", rezervacija.PonudaId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.Ponuda)
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id).ConfigureAwait(false);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Id == id);
        }
    }
}
