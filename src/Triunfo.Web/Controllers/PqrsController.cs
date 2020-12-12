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
    public class PqrsController : Controller
    {
        private readonly TriunfoDbContext _context;

        public PqrsController(TriunfoDbContext context)
        {
            _context = context;
        }

        // GET: Pqrs
        public async Task<IActionResult> Index()
        {
            var triunfoDbContext = _context.Pqr.Include(p => p.TipoDocumentoNavigation).Include(p => p.TipoSolicitudNavigation);
            return View(await triunfoDbContext.ToListAsync());
        }

        // GET: Pqrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqr = await _context.Pqr
                .Include(p => p.TipoDocumentoNavigation)
                .Include(p => p.TipoSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdPqr == id);
            if (pqr == null)
            {
                return NotFound();
            }

            return View(pqr);
        }

        // GET: Pqrs/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro");
            ViewData["TipoSolicitud"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro");
            return View();
        }

        // POST: Pqrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPqr,TipoDocumento,NumDocumento,Nombres,Apellidos,EMail,Telefono,TipoSolicitud,Mensaje")] Pqr pqr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoDocumento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoDocumento);
            ViewData["TipoSolicitud"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoSolicitud);
            return View(pqr);
        }

        // GET: Pqrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqr = await _context.Pqr.FindAsync(id);
            if (pqr == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoDocumento);
            ViewData["TipoSolicitud"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoSolicitud);
            return View(pqr);
        }

        // POST: Pqrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPqr,TipoDocumento,NumDocumento,Nombres,Apellidos,EMail,Telefono,TipoSolicitud,Mensaje")] Pqr pqr)
        {
            if (id != pqr.IdPqr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqrExists(pqr.IdPqr))
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
            ViewData["TipoDocumento"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoDocumento);
            ViewData["TipoSolicitud"] = new SelectList(_context.DetalleParametro, "IdDetParametro", "IdDetParametro", pqr.TipoSolicitud);
            return View(pqr);
        }

        // GET: Pqrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqr = await _context.Pqr
                .Include(p => p.TipoDocumentoNavigation)
                .Include(p => p.TipoSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdPqr == id);
            if (pqr == null)
            {
                return NotFound();
            }

            return View(pqr);
        }

        // POST: Pqrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqr = await _context.Pqr.FindAsync(id);
            _context.Pqr.Remove(pqr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqrExists(int id)
        {
            return _context.Pqr.Any(e => e.IdPqr == id);
        }
    }
}
