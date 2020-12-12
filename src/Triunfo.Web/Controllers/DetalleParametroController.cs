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
    public class DetalleParametroController : Controller
    {
        private readonly TriunfoDbContext _context;

        public DetalleParametroController(TriunfoDbContext context)
        {
            _context = context;
        }

        // GET: DetalleParametro
        public async Task<IActionResult> Index()
        {
            var triunfoDbContext = _context.DetalleParametro.Include(d => d.IdParametroNavigation);
            return View(await triunfoDbContext.ToListAsync());
        }

        // GET: DetalleParametro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleParametro = await _context.DetalleParametro
                .Include(d => d.IdParametroNavigation)
                .FirstOrDefaultAsync(m => m.IdDetParametro == id);
            if (detalleParametro == null)
            {
                return NotFound();
            }

            return View(detalleParametro);
        }

        // GET: DetalleParametro/Create
        public IActionResult Create()
        {
            ViewData["IdParametro"] = new SelectList(_context.Parametro, "IdParametro", "IdParametro");
            return View();
        }

        // POST: DetalleParametro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetParametro,IdParametro,ValorNumDetParametro,ValorStringDetParametro,DescripcionDetParametro,EstadoDetParametro")] DetalleParametro detalleParametro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleParametro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdParametro"] = new SelectList(_context.Parametro, "IdParametro", "IdParametro", detalleParametro.IdParametro);
            return View(detalleParametro);
        }

        // GET: DetalleParametro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleParametro = await _context.DetalleParametro.FindAsync(id);
            if (detalleParametro == null)
            {
                return NotFound();
            }
            ViewData["IdParametro"] = new SelectList(_context.Parametro, "IdParametro", "IdParametro", detalleParametro.IdParametro);
            return View(detalleParametro);
        }

        // POST: DetalleParametro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetParametro,IdParametro,ValorNumDetParametro,ValorStringDetParametro,DescripcionDetParametro,EstadoDetParametro")] DetalleParametro detalleParametro)
        {
            if (id != detalleParametro.IdDetParametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleParametro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleParametroExists(detalleParametro.IdDetParametro))
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
            ViewData["IdParametro"] = new SelectList(_context.Parametro, "IdParametro", "IdParametro", detalleParametro.IdParametro);
            return View(detalleParametro);
        }

        // GET: DetalleParametro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleParametro = await _context.DetalleParametro
                .Include(d => d.IdParametroNavigation)
                .FirstOrDefaultAsync(m => m.IdDetParametro == id);
            if (detalleParametro == null)
            {
                return NotFound();
            }

            return View(detalleParametro);
        }

        // POST: DetalleParametro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleParametro = await _context.DetalleParametro.FindAsync(id);
            _context.DetalleParametro.Remove(detalleParametro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleParametroExists(int id)
        {
            return _context.DetalleParametro.Any(e => e.IdDetParametro == id);
        }
    }
}
