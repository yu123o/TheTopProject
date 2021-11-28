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
    public class TasksController : Controller
    {
        private readonly TheTopDatabaseContext _context;
        const string AName = "Aname";
        const string EId = "EId";
        const string EAName = "EAname";

        const string AEName = "AEname";
        public TasksController(TheTopDatabaseContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            TempData[EId] = HttpContext.Session.GetInt32(EId);
            TempData[EAName] = HttpContext.Session.GetString(EAName);

            TempData[AEName] = HttpContext.Session.GetString(AEName);
            var theTopDatabaseContext = _context.Tasks.Include(t => t.Employee).OrderByDescending(x => x.InsertTime);
            
            if(TempData[EId] != null)
                 theTopDatabaseContext = _context.Tasks.Include(t => t.Employee).Where(x=> x.Employee.Id ==Convert.ToInt32(TempData[EId])).OrderByDescending(x => x.InsertTime);
         
            
            return View(await theTopDatabaseContext.ToListAsync());
        }
        public async Task<IActionResult> Finish()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            return View("Index", await _context.Tasks.OrderByDescending(x => x.InsertTime).Where(x=>x.Done == true).ToListAsync());
        }
        public async Task<IActionResult> UnFinish()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            return View("Index", await _context.Tasks.OrderByDescending(x => x.InsertTime).Where(x => x.Done == false).ToListAsync());
        }
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
           
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Email" );
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,TaskContent,InsertTime,FinishTime,Done,EmployeeId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                tasks.Done = false;
                tasks.InsertTime = DateTime.Now;
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", tasks.EmployeeId);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", tasks.EmployeeId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,TaskContent,InsertTime,FinishTime,Done,EmployeeId")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "DepartmentName", tasks.EmployeeId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
          
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Finished(int id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            Tasks task = _context.Tasks.Find(id);
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                task.Done = true;
                _context.Update(task);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
            //return View(contact);
        }

        public async Task<IActionResult> UnFinished(int id)
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
           
            Tasks task = _context.Tasks.Find(id);
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                task.Done = false;
                _context.Update(task);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
            //return View(contact);
        }
        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
