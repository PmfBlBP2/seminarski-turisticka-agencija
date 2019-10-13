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
    public class PonudaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public PonudaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: Ponuda
        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                    .Include(p => p.Prevoz.Kompanija)
                    .Include(p => p.Prevoz.TipPrevoza)
                .Include(p => p.Smjestaj);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        // GET: Ponuda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                .Include(p => p.Smjestaj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponuda == null)
            {
                return NotFound();
            }

            return View(ponuda);
        }

        // GET: Ponuda/Create
        public IActionResult Create()
        {
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad");
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis");
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv");
            return View();
        }

        // POST: Ponuda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SmjestajId,DestinacijaId,PrevozId,Naziv,DatumKreiranja,Pocetak,Kraj,Cijena")] Ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponuda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", ponuda.DestinacijaId);
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis", ponuda.PrevozId);
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv", ponuda.SmjestajId);
            return View(ponuda);
        }

        // GET: Ponuda/Edit/5
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

        // POST: Ponuda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SmjestajId,DestinacijaId,PrevozId,Naziv,DatumKreiranja,Pocetak,Kraj,Cijena")] Ponuda ponuda)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinacijaId"] = new SelectList(_context.Destinacija, "Id", "Grad", ponuda.DestinacijaId);
            ViewData["PrevozId"] = new SelectList(_context.Prevoz, "Id", "Opis", ponuda.PrevozId);
            ViewData["SmjestajId"] = new SelectList(_context.Smjestaj, "Id", "Naziv", ponuda.SmjestajId);
            return View(ponuda);
        }

        // GET: Ponuda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponuda
                .Include(p => p.Destinacija)
                .Include(p => p.Prevoz)
                .Include(p => p.Smjestaj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponuda == null)
            {
                return NotFound();
            }

            return View(ponuda);
        }

        // POST: Ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponuda = await _context.Ponuda.FindAsync(id);
            _context.Ponuda.Remove(ponuda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PonudaExists(int id)
        {
            return _context.Ponuda.Any(e => e.Id == id);
        }
    }
}
