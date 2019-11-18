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
    public class RezervacijaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public RezervacijaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

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

            var ponuda = _context.Ponuda
                .Where(x => x.Id == ponudaId)
                .FirstOrDefault();
            ViewBag.PonudaNaziv = ponuda.Naziv;
            ViewBag.PonudaId = ponudaId;

            var errMsg = TempData["ErrorMessage"] as string;

            if(errMsg != null)
            {
                ViewBag.ErrMsg = errMsg;
            }
            else
            {
                ViewBag.ErrMsg = "";
            }

            return View(await turistickaAgencijaContext.ToListAsync().ConfigureAwait(false));
        }

        public async Task<IActionResult> ExistingUserPartial()
        {
            var korisnik = _context.Korisnik
                .Select(x => new
                {
                    Id = x.Id,
                    Podaci = x.Ime.ToString() + " " + x.Prezime.ToString() + " [" + x.Email.ToString() + "]"
                });
            ViewData["KorisnikId"] = new SelectList(korisnik, "Id", "Podaci");
            return PartialView();
        }

        public async Task<IActionResult> NewUserPartial()
        {
            return PartialView();
        }


        public IActionResult Create(int? ponudaId)
        {
            if(ponudaId == null)
            {
                return NotFound();
            }
            var ponuda = _context.Ponuda
                .Where(x => x.Id == ponudaId)
                .FirstOrDefault();
            ViewBag.PonudaNaziv = ponuda.Naziv;
            ViewBag.PonudaId = ponudaId;
            var korisnik = _context.Korisnik
                .Select(x => new
                {
                    Id = x.Id,
                    Podaci = x.Ime.ToString() + " " + x.Prezime.ToString() + " [" + x.Email.ToString() + "]"
                });
            ViewData["KorisnikId"] = new SelectList(korisnik, "Id", "Podaci");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ponudaId, Rezervacija rezervacija)
        {
            if(rezervacija == null)
            {
                return NotFound();
            }
            int korisnikId = rezervacija.KorisnikId;

            // Ako unosimo novog korisnika u bazu, tada cemo njega prvo dodati u bazu Korisnik
            if(korisnikId == 0)
            {
                // Provjeravamo da li se vec u tabeli Korisnik nalazi korisnik sa istim imenom, prezimenom i Email adresom
                var existingUser = _context.Korisnik
                    .Where(x => x.Ime.ToLower().Trim() == rezervacija.Korisnik.Ime.ToLower().Trim() &&
                        x.Prezime.ToLower().Trim() == rezervacija.Korisnik.Prezime.ToLower().Trim() &&
                        x.Email.ToLower().Trim() == x.Email.ToLower().Trim())
                    .FirstOrDefault();

                if(existingUser != null)
                {
                    korisnikId = existingUser.Id;
                }
                else
                {
                    _context.Add(rezervacija.Korisnik);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    var noviKorisnik = _context.Korisnik
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefault();
                    korisnikId = noviKorisnik.Id;
                }
            }

            var korisnik = await _context.Korisnik.FindAsync(korisnikId).ConfigureAwait(false);
            if (korisnik == null)
            {
                return NotFound();
            }
            rezervacija.Korisnik = korisnik;

            var ponuda = await _context.Ponuda.FindAsync(rezervacija.PonudaId).ConfigureAwait(false);
            if(ponuda == null)
            {
                return NotFound();
            }

            var rezervacijaPostoji = _context.Rezervacija
                .Where(e => e.PonudaId == ponudaId && e.KorisnikId == korisnikId)
                .FirstOrDefault();
            if (rezervacijaPostoji != null)
            {
                TempData["ErrorMessage"] = "Korisnik " + korisnik.Ime + " " + korisnik.Prezime + " [" + korisnik.Email + "]" +
                    " je već rezervisao/la ponudu: " + ponuda.Naziv + "!";
                return RedirectToAction("Index", new { ponudaId = rezervacija.PonudaId });
            }

            if(ponuda.BrojMijesta == 0)
            {
                TempData["ErrorMessage"] = "Nema više slobodnih mijesta za ovu ponudu!";
                return RedirectToAction("Index", new { ponudaId = rezervacija.PonudaId });
            }

            if(ModelState.IsValid)
            {
                rezervacija.KorisnikId = korisnikId;
                rezervacija.Iznos = ponuda.Cijena;
                rezervacija.DatumRezervacije = DateTime.Now;
                
                ponuda.BrojMijesta -= 1;
                _context.Update(ponuda);
                
                _context.Add(rezervacija);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index", new { ponudaId = rezervacija.PonudaId });
            }

            var korisnikList = _context.Korisnik
                .Select(x => new
                {
                    Id = x.Id,
                    Podaci = x.Ime.ToString() + " " + x.Prezime.ToString() + " [" + x.Email.ToString() + "]"
                });
            ViewData["KorisnikId"] = new SelectList(korisnikList, "Id", "Podaci", rezervacija.KorisnikId);
            return View(rezervacija);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? ponudaId, int? korisnikId)
        {
            if (ponudaId == null || korisnikId == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(ponudaId, korisnikId).ConfigureAwait(false);
            if (rezervacija == null)
            {
                return NotFound();
            }

            var ponuda = _context.Ponuda
                .Where(x => x.Id == ponudaId)
                .FirstOrDefault();
            ViewBag.PonudaNaziv = ponuda.Naziv;

            var korisnik = _context.Korisnik
                .Where(x => x.Id == korisnikId)
                .FirstOrDefault();
            ViewBag.KorisnikIme = (korisnik.Ime + " " + korisnik.Prezime);

            ViewBag.PonudaIdEdit = ponudaId;

            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacija.KorisnikId);
            ViewData["PonudaId"] = new SelectList(_context.Ponuda, "Id", "Naziv", rezervacija.PonudaId);
            return View(rezervacija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ponudaId, int korisnikId, [Bind("Id,PonudaId,KorisnikId,DatumRezervacije,Iznos")] Rezervacija rezervacija)
        {
            if(rezervacija == null)
            {
                return NotFound();
            }
            if (ponudaId != rezervacija.PonudaId || korisnikId != rezervacija.KorisnikId)
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
                    if (!RezervacijaExists(rezervacija.PonudaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { ponudaId = rezervacija.PonudaId});
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "Id", "Ime", rezervacija.KorisnikId);
            ViewData["PonudaId"] = new SelectList(_context.Ponuda, "Id", "Naziv", rezervacija.PonudaId);
            return View(rezervacija);
        }

        [Authorize]
        public async Task<IActionResult> Remove(int ponudaId, int korisnikId)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(ponudaId, korisnikId).ConfigureAwait(false);

            var ponuda = await _context.Ponuda.FindAsync(ponudaId).ConfigureAwait(false);
            ponuda.BrojMijesta += 1;

            _context.Update(ponuda);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "Rezervacija", new { ponudaId = rezervacija.PonudaId });
        }

        private bool RezervacijaExists(int ponudaId)
        {
            return _context.Rezervacija.Any(e => e.PonudaId == ponudaId);
        }
    }
}
