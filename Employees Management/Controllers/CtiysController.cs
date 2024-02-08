using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employees_Management.Data;
using Employees_Management.Models;

namespace Employees_Management.Controllers
{
    public class CtiysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CtiysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ctiys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ctiy.Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ctiys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctiy = await _context.Ctiy
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ctiy == null)
            {
                return NotFound();
            }

            return View(ctiy);
        }

        // GET: Ctiys/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Couons, "Id", "Id");
            return View();
        }

        // POST: Ctiys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,CountryId")] Ctiy ctiy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctiy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Couons, "Id", "Id", ctiy.CountryId);
            return View(ctiy);
        }

        // GET: Ctiys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctiy = await _context.Ctiy.FindAsync(id);
            if (ctiy == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Couons, "Id", "Id", ctiy.CountryId);
            return View(ctiy);
        }

        // POST: Ctiys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,CountryId")] Ctiy ctiy)
        {
            if (id != ctiy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctiy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtiyExists(ctiy.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Couons, "Id", "Id", ctiy.CountryId);
            return View(ctiy);
        }

        // GET: Ctiys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctiy = await _context.Ctiy
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ctiy == null)
            {
                return NotFound();
            }

            return View(ctiy);
        }

        // POST: Ctiys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctiy = await _context.Ctiy.FindAsync(id);
            if (ctiy != null)
            {
                _context.Ctiy.Remove(ctiy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtiyExists(int id)
        {
            return _context.Ctiy.Any(e => e.Id == id);
        }
    }
}
