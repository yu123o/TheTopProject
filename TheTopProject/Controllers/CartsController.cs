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
    public class CartsController : Controller
    {
        private readonly TheTopDatabaseContext _context;
           const string Name = "Name";
            const string PhNumber = "PhNumber";
            const string UEmail = "email";
            const string address = "address";
            const string desc = "desc";
            const string subject = "subject";
        public CartsController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            TempData["Id"] = HttpContext.Session.GetInt32("Id");
          
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData[desc] = HttpContext.Session.GetString(desc);
            TempData[address] = HttpContext.Session.GetInt32(address);
            TempData[subject] = HttpContext.Session.GetString(subject);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");
           
            var theTopDatabaseContext = _context.Cart.Include(c => c.Customer).Where(c => c.Customer.Id == Convert.ToInt32(TempData["Id"])).Include(c => c.Design);
             ViewBag.Total =theTopDatabaseContext.Sum(x => x.Design.Cost);
           
            return View(await theTopDatabaseContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Customer)
                .Include(c => c.Design)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description");
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DesignId,CustomerId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", cart.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", cart.DesignId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", cart.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", cart.DesignId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DesignId,CustomerId")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", cart.CustomerId);
            ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", cart.DesignId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Customer)
                .Include(c => c.Design)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            HttpContext.Session.SetInt32("countOfElement", _context.Cart.Where(x => x.CustomerId == Convert.ToInt32(HttpContext.Session.GetInt32("Id"))).Count());

            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> Buy()
        //{
        //    var cart = await _context.Cart.FindAsync(id);
        //    _context.Cart.Remove(cart);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}
