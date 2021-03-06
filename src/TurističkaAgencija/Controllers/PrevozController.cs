﻿using System;
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
    public class PrevozController : Controller
    {
        private readonly TuristickaAgencijaContext _context;

        public PrevozController(TuristickaAgencijaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var turistickaAgencijaContext = _context.Prevoz.Include(p => p.Kompanija).Include(p => p.TipPrevoza);
            return View(await turistickaAgencijaContext.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["KompanijaId"] = new SelectList(_context.Kompanija, "Id", "Naziv");
            ViewData["TipPrevozaId"] = new SelectList(_context.TipPrevoza, "Id", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KompanijaId,TipPrevozaId,Opis,Slika")] Prevoz prevoz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prevoz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompanijaId"] = new SelectList(_context.Kompanija, "Id", "Naziv", prevoz.KompanijaId);
            ViewData["TipPrevozaId"] = new SelectList(_context.TipPrevoza, "Id", "Naziv", prevoz.TipPrevozaId);
            return View(prevoz);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevoz = await _context.Prevoz.FindAsync(id);
            if (prevoz == null)
            {
                return NotFound();
            }
            ViewData["KompanijaId"] = new SelectList(_context.Kompanija, "Id", "Naziv", prevoz.KompanijaId);
            ViewData["TipPrevozaId"] = new SelectList(_context.TipPrevoza, "Id", "Naziv", prevoz.TipPrevozaId);
            return View(prevoz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KompanijaId,TipPrevozaId,Opis,Slika")] Prevoz prevoz)
        {
            if (id != prevoz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prevoz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevozExists(prevoz.Id))
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
            ViewData["KompanijaId"] = new SelectList(_context.Kompanija, "Id", "Naziv", prevoz.KompanijaId);
            ViewData["TipPrevozaId"] = new SelectList(_context.TipPrevoza, "Id", "Naziv", prevoz.TipPrevozaId);
            return View(prevoz);
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var prevoz = await _context.Prevoz.FindAsync(id).ConfigureAwait(false);

            _context.Prevoz.Remove(prevoz);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "Prevoz");
        }

        private bool PrevozExists(int id)
        {
            return _context.Prevoz.Any(e => e.Id == id);
        }
    }
}
