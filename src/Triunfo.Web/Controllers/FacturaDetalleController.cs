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
    public class FacturaDetalleController : Controller
    {
        private readonly TriunfoDbContext _context;

        public FacturaDetalleController(TriunfoDbContext context)
        {
            _context = context;
        }

        // GET: FacturaDetalle
        public async Task<IActionResult> Index()
        {
            var triunfoDbContext = _context.FacturaDetalle.Include(f => f.DescuentoNavigation).Include(f => f.IdFacturaNavigation).Include(f => f.IdProductoNavigation);
            return View(await triunfoDbContext.ToListAsync());
        }

        // GET: FacturaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle
                .Include(f => f.DescuentoNavigation)
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDet == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Create
        public IActionResult Create()
        {
            ViewData["Descuento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro");
            ViewData["IdFactura"] = new SelectList(_context.FacturaCabecera, "IdFactura", "IdFactura");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto");
            return View();
        }

        // POST: FacturaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacturaDet,IdFactura,IdProducto,CantidadProducto,ValorUnitario,Descuento")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Descuento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", facturaDetalle.Descuento);
            ViewData["IdFactura"] = new SelectList(_context.FacturaCabecera, "IdFactura", "IdFactura", facturaDetalle.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle.FindAsync(id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }
            ViewData["Descuento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", facturaDetalle.Descuento);
            ViewData["IdFactura"] = new SelectList(_context.FacturaCabecera, "IdFactura", "IdFactura", facturaDetalle.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // POST: FacturaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacturaDet,IdFactura,IdProducto,CantidadProducto,ValorUnitario,Descuento")] FacturaDetalle facturaDetalle)
        {
            if (id != facturaDetalle.IdFacturaDet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetalleExists(facturaDetalle.IdFacturaDet))
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
            ViewData["Descuento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", facturaDetalle.Descuento);
            ViewData["IdFactura"] = new SelectList(_context.FacturaCabecera, "IdFactura", "IdFactura", facturaDetalle.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", facturaDetalle.IdProducto);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle
                .Include(f => f.DescuentoNavigation)
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdFacturaDet == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // POST: FacturaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDetalle = await _context.FacturaDetalle.FindAsync(id);
            _context.FacturaDetalle.Remove(facturaDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleExists(int id)
        {
            return _context.FacturaDetalle.Any(e => e.IdFacturaDet == id);
        }
    }
}
