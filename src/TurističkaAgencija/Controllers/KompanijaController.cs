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
    public class KompanijaController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public KompanijaController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        // GET: Kompanija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kompanija.ToListAsync());
        }

        // GET: Kompanija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kompanija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Grad")] Kompanija kompanija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kompanija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kompanija);
        }

        // GET: Kompanija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kompanija = await _context.Kompanija.FindAsync(id);
            if (kompanija == null)
            {
                return NotFound();
            }
            return View(kompanija);
        }

        // POST: Kompanija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Grad")] Kompanija kompanija)
        {
            if (id != kompanija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kompanija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KompanijaExists(kompanija.Id))
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
            return View(kompanija);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var kompanija = await _context.Kompanija.FindAsync(id).ConfigureAwait(false);

            _context.Kompanija.Remove(kompanija);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "Kompanija");
        }

        private bool KompanijaExists(int id)
        {
            return _context.Kompanija.Any(e => e.Id == id);
        }
    }
}
