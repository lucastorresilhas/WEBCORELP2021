﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCORELP2021.Models;
using WEBCORELP2021.Models.Dominio;

namespace WEBCORELP2021.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto _context;

        public ConsultaController(Contexto context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Consultas.Include(c => c.medico).Include(c => c.paciente);
            return View(await contexto.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.medico)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["medicoID"] = new SelectList(_context.Medicos, "id", "cidade");
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "id", "cidade");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,medicoID,pacienteID")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["medicoID"] = new SelectList(_context.Medicos, "id", "cidade", consulta.medicoID);
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "id", "cidade", consulta.pacienteID);
            return View(consulta);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["medicoID"] = new SelectList(_context.Medicos, "id", "cidade", consulta.medicoID);
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "id", "cidade", consulta.pacienteID);
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,medicoID,pacienteID")] Consulta consulta)
        {
            if (id != consulta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.id))
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
            ViewData["medicoID"] = new SelectList(_context.Medicos, "id", "cidade", consulta.medicoID);
            ViewData["pacienteID"] = new SelectList(_context.Pacientes, "id", "cidade", consulta.pacienteID);
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.medico)
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.id == id);
        }
    }
}
