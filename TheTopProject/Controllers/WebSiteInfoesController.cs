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
    public class WebSiteInfoesController : Controller
    {
        private readonly TheTopDatabaseContext _context;

        public WebSiteInfoesController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: WebSiteInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebSiteInfo.ToListAsync());
        }

        // GET: WebSiteInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }

            return View(webSiteInfo);
        }

        // GET: WebSiteInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebSiteInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,SmallDescription,Image")] WebSiteInfo webSiteInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webSiteInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webSiteInfo);
        }

        // GET: WebSiteInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo.FindAsync(id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }
            return View(webSiteInfo);
        }

        // POST: WebSiteInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,SmallDescription,Image")] WebSiteInfo webSiteInfo)
        {
            if (id != webSiteInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webSiteInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebSiteInfoExists(webSiteInfo.Id))
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
            return View(webSiteInfo);
        }

        // GET: WebSiteInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }

            return View(webSiteInfo);
        }

        // POST: WebSiteInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webSiteInfo = await _context.WebSiteInfo.FindAsync(id);
            _context.WebSiteInfo.Remove(webSiteInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebSiteInfoExists(int id)
        {
            return _context.WebSiteInfo.Any(e => e.Id == id);
        }
    }
}
