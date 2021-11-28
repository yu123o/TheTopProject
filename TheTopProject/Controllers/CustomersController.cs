using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopProject.Models;

namespace TheTopProject.Controllers
{
    
    public class CustomersController : Controller
    {
        private readonly TheTopDatabaseContext _context;
            const string AName = "Aname";
            const string APhNumber = "APhNumber";
            const string AUEmail = "Aemail";
        public CustomersController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            return View(await _context.Customer.ToListAsync());
        }
        public async Task<IActionResult> Newest()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            return View("Index", await _context.Customer.OrderByDescending(x => x.RegistrationTime).ToListAsync());
        }
        public IActionResult Search(string CustomerName)
        {

            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var table = _context.Customer.Where(x => x.Fname.Contains(CustomerName) || x.Lname.Contains(CustomerName)).ToList();
            //Category c = context.Category.Find(CategoryName);
            ViewBag.search = CustomerName;
            if (table == null)
                return NotFound();
            return View("Index", table);
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname,Email,Password,Subject,Description,PhoneNumber,RegistrationTime,Address")] Customer customer)
        {
           
            if (ModelState.IsValid && !_context.Customer.Any(x => x.Email == customer.Email))
            {
                customer.RegistrationTime = DateTime.Now;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Home");
            }
            else if(_context.Customer.Any(x => x.Email == customer.Email))
                    ViewBag.M = "This email already exists!";
            else if(!ModelState.IsValid)
                    ViewBag.M = "Please Add your Information!";
            return  View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit()
        {
            TempData["Id"] = HttpContext.Session.GetInt32("Id");

            if (TempData["Id"]== null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(Convert.ToInt32(TempData["Id"]));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("Id,Fname,Lname,Email,Password,Subject,Description,PhoneNumber,RegistrationTime,Address")] Customer customer)
        {
            TempData["Id"] = HttpContext.Session.GetInt32("Id");

            if (Convert.ToInt32(TempData["Id"]) != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("OwnProfile","Home");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
