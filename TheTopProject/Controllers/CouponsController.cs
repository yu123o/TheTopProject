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
    public class CouponsController : Controller
    {
        private readonly TheTopDatabaseContext _context;
        const string AName = "Aname";
        const string APhNumber = "APhNumber";
        const string AUEmail = "Aemail";
        public CouponsController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Coupons
        public async Task<IActionResult> Index()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            return View(await _context.Coupon.OrderByDescending(x=>x.StartTime).ToListAsync());
        }
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var coupon = await _context.Coupon.FindAsync(id);
            _context.Coupon.Remove(coupon);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Coupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // GET: Coupons/Create
        public IActionResult Create()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Amount,StartTime,FinishTime")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                coupon.StartTime = DateTime.Now;
                _context.Add(coupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupon);
        }

        // GET: Coupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Amount,StartTime,FinishTime")] Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponExists(coupon.Id))
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
            return View(coupon);
        }

        // GET: Coupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupon = await _context.Coupon.FindAsync(id);
            _context.Coupon.Remove(coupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponExists(int id)
        {
            return _context.Coupon.Any(e => e.Id == id);
        }
    }
}
