using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Triunfo.Core.Domain;
using Triunfo.Infrastructure.Data;

namespace Triunfo.Web.Controllers
{
    public class FacturaCabeceraController : Controller
    {
        private readonly TriunfoDbContext _context;

        public FacturaCabeceraController(TriunfoDbContext context)
        {
            _context = context;
        }

        // GET: FacturaCabecera
        public async Task<IActionResult> Index()
        {
            var triunfoDbContext = _context.FacturaCabecera.Include(f => f.IdClienteNavigation).Include(f => f.IdVendedorNavigation);
            return View(await triunfoDbContext.ToListAsync());
        }

        // GET: FacturaCabecera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabecera
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return View(facturaCabecera);
        }

        // GET: FacturaCabecera/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona");
            ViewData["IdVendedor"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona");
            return View();
        }

        // POST: FacturaCabecera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,IdCliente,IdVendedor,FechaFactura")] FacturaCabecera facturaCabecera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaCabecera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdVendedor);
            return View(facturaCabecera);
        }

        // GET: FacturaCabecera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabecera.FindAsync(id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdVendedor);
            return View(facturaCabecera);
        }

        // POST: FacturaCabecera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,IdCliente,IdVendedor,FechaFactura")] FacturaCabecera facturaCabecera)
        {
            if (id != facturaCabecera.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaCabecera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaCabeceraExists(facturaCabecera.IdFactura))
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
            ViewData["IdCliente"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdCliente);
            ViewData["IdVendedor"] = new SelectList(_context.Persona, "IdPersona", "ApellidoPersona", facturaCabecera.IdVendedor);
            return View(facturaCabecera);
        }

        // GET: FacturaCabecera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCabecera = await _context.FacturaCabecera
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }

            return View(facturaCabecera);
        }

        // POST: FacturaCabecera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaCabecera = await _context.FacturaCabecera.FindAsync(id);
            _context.FacturaCabecera.Remove(facturaCabecera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaCabeceraExists(int id)
        {
            return _context.FacturaCabecera.Any(e => e.IdFactura == id);
        }
    }
}
