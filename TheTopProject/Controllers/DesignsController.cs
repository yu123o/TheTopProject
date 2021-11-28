using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTopProject.Models;

namespace TheTopProject.Controllers
{
    public class DesignsController : Controller
    {
        const string Id = "Id";
        const string Name = "Name";
        const string PhNumber = "PhNumber";
        const string UEmail = "email";
        const string AName = "Aname";
        const string APhNumber = "APhNumber";
        const string AUEmail = "Aemail";
        private readonly TheTopDatabaseContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DesignsController(TheTopDatabaseContext context, IWebHostEnvironment _hostEnvironment)
        {
           
            _context = context;
            this._hostEnvironment = _hostEnvironment;
        }

        // GET: Designs
        public async Task<IActionResult> Index()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var theTopDatabaseContext = _context.Design.Include(d => d.Categroy).Include(d => d.Customer).Where(x=>x.Customer.Id ==Convert.ToInt32( TempData[Id]));
            return View(await theTopDatabaseContext.ToListAsync());
        }
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[APhNumber] = HttpContext.Session.GetInt32(APhNumber);
            TempData[AUEmail] = HttpContext.Session.GetString(AUEmail);
            var des = await _context.Design.FindAsync(id);
            _context.Design.Remove(des);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Designs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Design
                .Include(d => d.Categroy)
                .Include(d => d.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (design == null)
            {
                return NotFound();
            }

            return View(design);
        }

        // GET: Designs/Create
        public IActionResult Create()
        {

            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);

            ViewData["CategroyId"] = new SelectList(_context.Category, "Id", "Image");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description");
            return View();
        }

        // POST: Designs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Width,Height,Cost,Image,CategroyId,CustomerId,ImageFile")] Design design)
        {

            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);

            if (ModelState.IsValid)
            {   
                string wwwRootPath = _hostEnvironment.WebRootPath;//C:\Users\User\Desktop\ProjectMVC\wwwroot\
                string fileName = Guid.NewGuid().ToString() + "_" + design.ImageFile.FileName;
                string extension = Path.GetExtension(design.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/assets/img/Design/" + fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await design.ImageFile.CopyToAsync(fileStream);


                }
                design.Image = fileName;
                design.CategroyId = Convert.ToInt32(TempData["CategoryId"]);
                if (TempData[Id] != null)
                {
                    design.CustomerId = Convert.ToInt32(TempData[Id]);
                }
                else
                {
                    ViewBag.Login = "Please Sign In";
                    return View();
                }
                design.AddDate = DateTime.Now;
                _context.Add(design);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategroyId"] = new SelectList(_context.Category, "Id", "Image", design.CategroyId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", design.CustomerId);
            return View(design);
        }

        // GET: Designs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Design.FindAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            ViewData["CategroyId"] = new SelectList(_context.Category, "Id", "Image", design.CategroyId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", design.CustomerId);
            return View(design);
        }

        // POST: Designs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Width,Height,Cost,Image,CategroyId,CustomerId")] Design design)
        {
            if (id != design.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(design);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignExists(design.Id))
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
            ViewData["CategroyId"] = new SelectList(_context.Category, "Id", "Image", design.CategroyId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", design.CustomerId);
            return View(design);
        }

        // GET: Designs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _context.Design
                .Include(d => d.Categroy)
                .Include(d => d.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (design == null)
            {
                return NotFound();
            }

            return View(design);
        }

        // POST: Designs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var design = await _context.Design.FindAsync(id);
            _context.Design.Remove(design);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignExists(int id)
        {
            return _context.Design.Any(e => e.Id == id);
        }
    }
}
