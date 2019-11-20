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
    public class PonudaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public PonudaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = await _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj)
                .ToListAsync().ConfigureAwait(false);

            var minCijena = _context.Ponuda
                .OrderBy(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var maxCijena = _context.Ponuda
                .OrderByDescending(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var minDatum = _context.Ponuda
                .OrderBy(x => x.Pocetak)
                .Select(x => x.Pocetak)
                .FirstOrDefault();

            var maxDatum = _context.Ponuda
                .OrderByDescending(x => x.Kraj)
                .Select(x => x.Kraj)
                .FirstOrDefault();

            ViewBag.minCijena = minCijena;
            ViewBag.maxCijena = maxCijena;
            ViewBag.minDatum = minDatum.Year + "-" + minDatum.Month.ToString("00") + "-" + minDatum.Day.ToString("00");
            ViewBag.maxDatum = maxDatum.Year + "-" + maxDatum.Month.ToString("00") + "-" + maxDatum.Day.ToString("00");

            var topTri = await _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj)
                .OrderByDescending(x => x.Id)
                .Take(3)
                .ToListAsync().ConfigureAwait(false);

            Home home = new Home
            {
                Ponuda = turistickaAgencijaContext,
                TopTri = topTri
            };
            return View(home);
        }

        public async Task<IActionResult> List ()
        {
            var turistickaAgencijaContext = await _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj)
                .ToListAsync().ConfigureAwait(false);

            return View(turistickaAgencijaContext);
        }

        public IActionResult Search()
        {
            var minCijena = _context.Ponuda
                .OrderBy(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var maxCijena = _context.Ponuda
                .OrderByDescending(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var minDatum = _context.Ponuda
                .OrderBy(x => x.Pocetak)
                .Select(x => x.Pocetak)
                .FirstOrDefault();

            var maxDatum = _context.Ponuda
                .OrderByDescending(x => x.Kraj)
                .Select(x => x.Kraj)
                .FirstOrDefault();

            ViewBag.minCijena = minCijena;
            ViewBag.maxCijena = maxCijena;
            ViewBag.minDatum = minDatum.Year + "-" + minDatum.Month.ToString("00") + "-" + minDatum.Day.ToString("00");
            ViewBag.maxDatum = maxDatum.Year + "-" + maxDatum.Month.ToString("00") + "-" + maxDatum.Day.ToString("00");

            Home home = new Home
            {
                Ponuda = null,
                Pretraga = null
            };
            return View(home);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(Pretraga pretraga)
        {
            if (pretraga == null)
            {
                return NotFound();
            }
            var rezultat = _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj)
                .AsQueryable();

            rezultat = rezultat.Where(x => x.Id > 0);

            if (!string.IsNullOrEmpty(pretraga.Destinacija))
            {
                rezultat = rezultat.Where(x => x.Destinacija.Grad.ToLower().Contains(pretraga.Destinacija.ToLower()));
            }
            if (pretraga.DatumOd.HasValue)
            {
                rezultat = rezultat.Where(x => DateTime.Compare(x.Pocetak, (DateTime)pretraga.DatumOd) >= 0);
            }
            if (pretraga.DatumDo.HasValue)
            {
                rezultat = rezultat.Where(x => DateTime.Compare(x.Kraj, (DateTime)pretraga.DatumDo) <= 0);
            }
            if (pretraga.CijenaOd.HasValue)
            {
                rezultat = rezultat.Where(x => x.Cijena >= pretraga.CijenaOd);
            }
            if (pretraga.CijenaDo.HasValue)
            {
                rezultat = rezultat.Where(x => x.Cijena <= pretraga.CijenaDo);
            }
            rezultat.ToList();


            var minCijena = _context.Ponuda
                .OrderBy(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var maxCijena = _context.Ponuda
                .OrderByDescending(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var minDatum = new DateTime();

            if (pretraga.DatumOd.HasValue)
            {
                minDatum = (DateTime)pretraga.DatumOd;
            }

            var maxDatum = new DateTime();
            
            if(pretraga.DatumDo.HasValue)
            {
                maxDatum = (DateTime)pretraga.DatumDo;
            }
            

            ViewBag.minCijena = minCijena;
            ViewBag.maxCijena = maxCijena;
            ViewBag.minDatum = minDatum.Year + "-" + minDatum.Month.ToString("00") + "-" + minDatum.Day.ToString("00");
            ViewBag.maxDatum = maxDatum.Year + "-" + maxDatum.Month.ToString("00") + "-" + maxDatum.Day.ToString("00");

            Home home = new Home
            {
                Ponuda = rezultat
            };
            return View(home);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minCijena = _context.Ponuda
                .OrderBy(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var maxCijena = _context.Ponuda
                .OrderByDescending(x => x.Cijena)
                .Select(x => x.Cijena)
                .FirstOrDefault();

            var minDatum = _context.Ponuda
                .OrderBy(x => x.Pocetak)
                .Select(x => x.Pocetak)
                .FirstOrDefault();

            var maxDatum = _context.Ponuda
                .OrderByDescending(x => x.Kraj)
                .Select(x => x.Kraj)
                .FirstOrDefault();

            ViewBag.minCijena = minCijena;
            ViewBag.maxCijena = maxCijena;
            ViewBag.minDatum = minDatum.Year + "-" + minDatum.Month.ToString("00") + "-" + minDatum.Day.ToString("00");
            ViewBag.maxDatum = maxDatum.Year + "-" + maxDatum.Month.ToString("00") + "-" + maxDatum.Day.ToString("00");

            var ponuda = await _context.Ponuda
                .Include(p => p.Destinacija)
                    .ThenInclude(p => p.Drzava)
                .Include(p => p.Prevoz)
                .Include(p => p.Prevoz)
                    .ThenInclude(p => p.TipPrevoza)
                .Include(p => p.Prevoz)
                    .ThenInclude(p => p.Kompanija)
                .Include(p => p.Smjestaj)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (ponuda == null)
            {
                return NotFound();
            }

            Home home = new Home
            {
                JednaPonuda = ponuda
            };
            return View(home);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad");
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis");
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SmjestajId,DestinacijaId,PrevozId,Naziv,Opis,Slika,Pocetak,Kraj,Cijena,BrojMijesta")] Ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                ponuda.DatumKreiranja = DateTime.Now;
                _context.Add(ponuda);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", ponuda.DestinacijaId);
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis", ponuda.PrevozId);
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv", ponuda.SmjestajId);
            return View(ponuda);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponuda.FindAsync(id);
            if (ponuda == null)
            {
                return NotFound();
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", ponuda.DestinacijaId);
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis", ponuda.PrevozId);
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv", ponuda.SmjestajId);
            return View(ponuda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SmjestajId,DestinacijaId,PrevozId,Naziv,Opis,Slika,DatumKreiranja,Pocetak,Kraj,Cijena,BrojMijesta")] Ponuda ponuda)
        {
            if (id != ponuda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponuda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PonudaExists(ponuda.Id))
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
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", ponuda.DestinacijaId);
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis", ponuda.PrevozId);
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv", ponuda.SmjestajId);
            return View(ponuda);
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var ponuda = await _context.Ponuda.FindAsync(id).ConfigureAwait(false);

            _context.Ponuda.Remove(ponuda);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("List", "Ponuda");
        }

        private bool PonudaExists(int id)
        {
            return _context.Ponuda.Any(e => e.Id == id);
        }
    }
}
