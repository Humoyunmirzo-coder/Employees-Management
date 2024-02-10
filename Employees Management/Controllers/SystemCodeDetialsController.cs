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
    public class SystemCodeDetialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemCodeDetials
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SystemCodeDetial.Include(s => s.SystemCode);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SystemCodeDetials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCodeDetial = await _context.SystemCodeDetial
                .Include(s => s.SystemCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemCodeDetial == null)
            {
                return NotFound();
            }

            return View(systemCodeDetial);
        }

        // GET: SystemCodeDetials/Create
        public IActionResult Create()
        {
            ViewData["SystemCodeId"] = new SelectList(_context.SystemCodes, "Id", "Description");
            return View();
        }

        // POST: SystemCodeDetials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemCodeDetial systemCodeDetial)
        {
            
                _context.Add(systemCodeDetial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["SystemCodeId"] = new SelectList(_context.SystemCodes, "Id", "Description", systemCodeDetial.SystemCodeId);
            return View(systemCodeDetial);
        }

        // GET: SystemCodeDetials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCodeDetial = await _context.SystemCodeDetial.FindAsync(id);
            if (systemCodeDetial == null)
            {
                return NotFound();
            }
            ViewData["SystemCodeId"] = new SelectList(_context.SystemCodes, "Id", "Id", systemCodeDetial.SystemCodeId);
            return View(systemCodeDetial);
        }

        // POST: SystemCodeDetials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SystemCodeId,Code,Description,OrderNo,CreateId,CreateOn,ModifiedById,ModifiedOn")] SystemCodeDetial systemCodeDetial)
        {
            if (id != systemCodeDetial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemCodeDetial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemCodeDetialExists(systemCodeDetial.Id))
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
            ViewData["SystemCodeId"] = new SelectList(_context.SystemCodes, "Id", "Id", systemCodeDetial.SystemCodeId);
            return View(systemCodeDetial);
        }

        // GET: SystemCodeDetials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCodeDetial = await _context.SystemCodeDetial
                .Include(s => s.SystemCode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemCodeDetial == null)
            {
                return NotFound();
            }

            return View(systemCodeDetial);
        }

        // POST: SystemCodeDetials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemCodeDetial = await _context.SystemCodeDetial.FindAsync(id);
            if (systemCodeDetial != null)
            {
                _context.SystemCodeDetial.Remove(systemCodeDetial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemCodeDetialExists(int id)
        {
            return _context.SystemCodeDetial.Any(e => e.Id == id);
        }
    }
}
