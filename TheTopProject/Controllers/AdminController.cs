
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TheTopProject.Models;
using RotativaCore;
using Microsoft.AspNetCore.Hosting;

namespace TheTopProject.Controllers
{
    public class AdminController : Controller
    {
        const string AId = "AId";
        const string AName = "Aname";
      

        const string EId = "EId";
        const string EAName = "EAname";
       
        const string AEName = "AEname";
       
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly TheTopDatabaseContext context;
        public AdminController( TheTopDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }

        public IActionResult Index()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);

            TempData[EId] = HttpContext.Session.GetInt32(EId);
            TempData[EAName] = HttpContext.Session.GetString(EAName);

            TempData[AEName] = HttpContext.Session.GetString(AEName);


            ViewBag.SalesAmount = context.Sales.Sum(x => x.Design.Cost);
            ViewBag.profits = context.Sales.Sum(x => x.Design.Cost * 0.1);
            ViewBag.NumberOfCustomer = context.Customer.Count();
            
            return View();
        }
        public IActionResult Feedback()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
           
            var table = context.Contact.OrderByDescending(x => x.Time).ToList();
            return View(table);
        }
        public IActionResult Approved()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
          
            var table = context.Contact.Where(x => x.Approve == true).OrderByDescending(x => x.Time).ToList();
            return View("Feedback", table);
        }
        public IActionResult Unapproved()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            var table = context.Contact.Where(x => x.Approve == false).OrderByDescending(x => x.Time).ToList();
            return View("Feedback", table);
        }
        public IActionResult OrderByTime()
        {
            TempData[AName] = HttpContext.Session.GetString(AName);
            
            var table = context.Contact.OrderBy(x => x.Time).ToList();
            return View("Feedback", table);
        }
        public IActionResult LogOut()
        {
            
            HttpContext.Session.Remove(AName);
            HttpContext.Session.Remove(EAName);
            HttpContext.Session.Remove(AEName);
            HttpContext.Session.Remove(AId);
          


            var table = context.Category.ToList();
            return RedirectToAction("Index", "Home", table);

        }

        public IActionResult PrintSales()
        {
            var Sales = context.Sales.ToList();

           

            Reports.AnnualSallesReports rpt = new Reports.AnnualSallesReports(webHostEnvironment, context);

            return File(rpt.Report(Sales), "application/pdf");
        }
        public IActionResult MonthlyPrintSales()
        {
            var Sales = context.Sales.ToList();
          

            Reports.MonthlySallesReports rpt = new Reports.MonthlySallesReports(webHostEnvironment, context);

            return File(rpt.Report(Sales), "application/pdf");
        }

        public IActionResult FinancialMonthlyReports()
        {
            var Sales = context.Sales.ToList();

        
            Reports.FinancialMonthlyReports rpt = new Reports.FinancialMonthlyReports(webHostEnvironment, context);

            return File(rpt.Report(Sales), "application/pdf");
        }
        public IActionResult FinancialAnnualReports()
        {
            var Sales = context.Customer.ToList();


            Reports.FinancialAnnualReport rpt = new Reports.FinancialAnnualReport(webHostEnvironment, context);

            return File(rpt.Report(Sales), "application/pdf");
        }
        public IActionResult SalarySlip()
        {
            
           
            Reports.SalarySlip rpt = new Reports.SalarySlip(webHostEnvironment, context);
            if (TempData[EAName] != null)
            {
                TempData[EId] = HttpContext.Session.GetInt32(EId);

                TempData[EAName] = HttpContext.Session.GetString(EAName);
                return File(rpt.Report(Convert.ToString(TempData[EAName]),Convert.ToInt32(TempData[EId])), "application/pdf");
            }
            TempData[EId] = HttpContext.Session.GetInt32(EId);

            TempData[AEName] = HttpContext.Session.GetString(AEName);
            return File(rpt.Report(Convert.ToString(TempData[EAName]), Convert.ToInt32(TempData[EId])), "application/pdf");
        }
    }
}
