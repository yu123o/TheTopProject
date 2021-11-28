using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopProject.Models;

namespace TheTopProject.Controllers
{
    public class DeductionsController : Controller
    {
        private readonly TheTopDatabaseContext _context;

        public DeductionsController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Detuctions
        public async Task<IActionResult> Index()
        {
            var theTopDatabaseContext = _context.Deduction.Include(d => d.Employee);
            return View(await theTopDatabaseContext.ToListAsync());
        }

        // GET: Detuctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detuction = await _context.Deduction
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detuction == null)
            {
                return NotFound();
            }

            return View(detuction);
        }

        // GET: Detuctions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Description");
            return View();
        }

        // POST: Detuctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,EmployeeId")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Description", deduction.EmployeeId);
            return View(deduction);
        }

        // GET: Detuctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detuction = await _context.Deduction.FindAsync(id);
            if (detuction == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Description", detuction.EmployeeId);
            return View(detuction);
        }

        // POST: Detuctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,EmployeeId")] Deduction deduction)
        {
            if (id != deduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetuctionExists(deduction.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Description", deduction.EmployeeId);
            return View(deduction);
        }

        // GET: Detuctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detuction = await _context.Deduction
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detuction == null)
            {
                return NotFound();
            }

            return View(detuction);
        }

        // POST: Detuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detuction = await _context.Deduction.FindAsync(id);
            _context.Deduction.Remove(detuction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetuctionExists(int id)
        {
            return _context.Deduction.Any(e => e.Id == id);
        }
    }
}
