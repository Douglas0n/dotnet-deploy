using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace projetos.Controllers
{
    public class NomesController : Controller
    {
        private readonly NomesContext _context;

        public NomesController(NomesContext context)
        {
            _context = context;
        }

        // GET: Nomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nomes.ToListAsync());
        }

        // GET: Nomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomes = await _context.Nomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomes == null)
            {
                return NotFound();
            }

            return View(nomes);
        }

        // GET: Nomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Snome")] Nomes nomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nomes);
        }

        // GET: Nomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomes = await _context.Nomes.FindAsync(id);
            if (nomes == null)
            {
                return NotFound();
            }
            return View(nomes);
        }

        // POST: Nomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Snome")] Nomes nomes)
        {
            if (id != nomes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nomes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NomesExists(nomes.Id))
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
            return View(nomes);
        }

        // GET: Nomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await DeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        // POST: Nomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomes = await _context.Nomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomes == null)
            {
                return NotFound();
            }

            nomes = await _context.Nomes.FindAsync(id);
            _context.Nomes.Remove(nomes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NomesExists(int id)
        {
            return _context.Nomes.Any(e => e.Id == id);
        }
    }
}
