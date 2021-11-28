using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopProject.Models;

namespace TheTopProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly TheTopDatabaseContext _context;
        const string AName = "Aname";
        const string APhNumber = "APhNumber";
        const string AUEmail = "Aemail";
        public SalesController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var theTopDatabaseContext = _context.Sales.Include(s => s.Customer).Include(s => s.Design);
            return View(await theTopDatabaseContext.ToListAsync());
        }
        public async Task<IActionResult> Newest()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var theTopDatabaseContext =  _context.Sales.OrderBy(x => x.CustomerId).OrderByDescending(x => x.Date).Include(s => s.Customer).Include(s => s.Design);
            return View("Index", await theTopDatabaseContext.ToListAsync());
        }
        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Design)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description");
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,CompanyRatio,DesignId,CustomerId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", sales.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", sales.DesignId);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", sales.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", sales.DesignId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,CompanyRatio,DesignId,CustomerId")] Sales sales)
        {
            if (id != sales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesExists(sales.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", sales.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", sales.DesignId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Design)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
