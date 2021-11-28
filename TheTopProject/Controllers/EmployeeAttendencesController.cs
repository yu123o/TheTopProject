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
    public class EmployeeAttendencesController : Controller
    {
        private readonly TheTopDatabaseContext _context;

        public EmployeeAttendencesController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: EmployeeAttendences
        public async Task<IActionResult> Index()
        {
            var theTopDatabaseContext = _context.EmployeeAttendence.Include(e => e.Employee);
            return View(await theTopDatabaseContext.ToListAsync());
        }

        // GET: EmployeeAttendences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAttendence = await _context.EmployeeAttendence
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAttendence == null)
            {
                return NotFound();
            }

            return View(employeeAttendence);
        }

        // GET: EmployeeAttendences/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName");
            return View();
        }

        // POST: EmployeeAttendences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoginTime,LogoutTime,NumberOfHours,EmployeeId")] EmployeeAttendence employeeAttendence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAttendence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", employeeAttendence.EmployeeId);
            return View(employeeAttendence);
        }

        // GET: EmployeeAttendences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAttendence = await _context.EmployeeAttendence.FindAsync(id);
            if (employeeAttendence == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", employeeAttendence.EmployeeId);
            return View(employeeAttendence);
        }

        // POST: EmployeeAttendences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoginTime,LogoutTime,NumberOfHours,EmployeeId")] EmployeeAttendence employeeAttendence)
        {
            if (id != employeeAttendence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAttendence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAttendenceExists(employeeAttendence.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", employeeAttendence.EmployeeId);
            return View(employeeAttendence);
        }

        // GET: EmployeeAttendences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAttendence = await _context.EmployeeAttendence
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAttendence == null)
            {
                return NotFound();
            }

            return View(employeeAttendence);
        }

        // POST: EmployeeAttendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeAttendence = await _context.EmployeeAttendence.FindAsync(id);
            _context.EmployeeAttendence.Remove(employeeAttendence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAttendenceExists(int id)
        {
            return _context.EmployeeAttendence.Any(e => e.Id == id);
        }
    }
}
