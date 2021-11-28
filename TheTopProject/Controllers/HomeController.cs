using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTopProject.Models;
using TheTopProject.Reports;

namespace TheTopProject.Controllers
{
    public class HomeController : Controller
    {
        const string Id = "Id";
        const string Name = "Name";
        const string PhNumber = "PhNumber";
        const string UEmail = "email";
        //const string address = "address";
        const string desc = "desc";
        const string subject = "subject";
        //const string AId = "AId";
        const string AName = "Aname";
       

        const string EId = "EId";
        const string EAName = "EAname";
        

        const string AEName = "AEname";
        
        //const string Aaddress = "Aaddress";
        //const string Adesc = "Adesc";
        //const string Asubject = "Asubject";
        private readonly ILogger<HomeController> _logger;
        private readonly TheTopDatabaseContext context;

        public HomeController(ILogger<HomeController> logger, TheTopDatabaseContext context)
        {
           
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            ViewBag.xx = 1000000;
            var table = context.Category.ToList();
            return View(table);
        }
        public IActionResult Search(string CategoryName)
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);

            var table = context.Category.Where(x=> x.Title.Contains(CategoryName) ).ToList();
            //Category c = context.Category.Find(CategoryName);
            ViewBag.search = CategoryName;
            if (table == null)
                return NotFound();
            return View("Index",table);
        }
        public IActionResult Designs(int id) 
        {
            TempData["CatId"] = id;
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            Category c = context.Category.Find(id);
            ViewBag.cat = c.Title;
         

            HttpContext.Session.SetInt32("CategoryId", c.Id);
            TempData["CategoryId"] = HttpContext.Session.GetInt32("CategoryId");
           
            var result = context.Design.Where(x => x.CategroyId == id).ToList();
            return View(result);
        }
        public IActionResult SearchByDate(DateTime firstDate, DateTime lastDate)
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            if (firstDate != null && lastDate != null && firstDate.Date<=lastDate.Date)
            {
                ViewBag.FirstTime = "From:  "+firstDate.Date.ToShortDateString() +"           To:  "+ lastDate.Date.ToShortDateString();
                var table = context.Design.Where(x => x.AddDate >= firstDate.Date && x.AddDate <= lastDate.Date).ToList();
                return View("Designs", table);
            }
            else
                return NotFound();
            
        }
      
    
        public IActionResult AboutUs()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            return View();

        }
        public IActionResult Privacy()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            return View();
        }
        public IActionResult ContactUs()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            return View();

        }
        public IActionResult Feedback()
        {
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            var table = context.Contact.Where(x=> x.Approve == true).ToList();
            return View(table);

        }
        public IActionResult Profile(int id)
        {
            Design d = context.Design.Find(id);

            Customer c = context.Customer.Find(d.CustomerId);
            ViewBag.des = d.CustomerId;
            ViewBag.fullName = c.Fname + " " + c.Lname;
            ViewBag.subject = c.Subject;
            ViewBag.description = c.Description;
            ViewBag.address = c.Address;
            ViewBag.time = c.RegistrationTime;
            ViewBag.em = c.Email;
            ViewBag.phn = c.PhoneNumber;
             var  designRes = context.Design.Where(x => x.CustomerId == d.CustomerId).ToList();
          

            //var result = context.Customer.Where(x => x.Id == d.CustomerId).ToList();
           

            return View(designRes);
        }
        public IActionResult OwnProfile()
        {

            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            TempData[Id] = HttpContext.Session.GetInt32(Id);
                TempData[Name] = HttpContext.Session.GetString(Name);
                TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
                TempData[UEmail] = HttpContext.Session.GetString(UEmail);
                TempData[desc] = HttpContext.Session.GetString(desc);
                //TempData[address] = HttpContext.Session.GetInt32(address);
                TempData[subject] = HttpContext.Session.GetString(subject);
                var designRes = context.Design.Where(x => x.CustomerId == Convert.ToInt32(TempData[Id])).ToList();
            


            //var result = context.Customer.Where(x => x.Id == d.CustomerId).ToList();


            return View(designRes);
        }


        public async Task<IActionResult> Buy(int number)
        {

            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData[desc] = HttpContext.Session.GetString(desc);
            //TempData[address] = HttpContext.Session.GetInt32(address);
            //TempData[subject] = HttpContext.Session.GetString(subject);
            var theTopDatabaseContext = context.Cart.Include(c => c.Customer).Where(c => c.Customer.Id == Convert.ToInt32(TempData["Id"])).Include(c => c.Design);
            var Total = theTopDatabaseContext.Sum(x => x.Design.Cost);
            var cart =context.Cart.Where(x => x.CustomerId == Convert.ToInt32(TempData[Id])).ToList();
           
            if (number.ToString() != null)
                if(context.CreditCard.Where(x => x.Number==number).ToList() != null)
                   if(context.CreditCard.Where(x => x.Number == number && x.Balance >= Total ).ToList() != null){
                      Sales sales = new Sales();
                      foreach(Cart c in cart) {
                             sales = new Sales();
                             sales.CustomerId = c.CustomerId;
                             sales.DesignId = c.DesignId;
                             sales.CompanyRatio = 0.10 ;
                             sales.Date = DateTime.Now;
                             await context.Sales.AddAsync(sales);
                             await context.SaveChangesAsync();
                             context.Cart.Remove(c);
                             await context.SaveChangesAsync();
                           
                        }
                        HttpContext.Session.SetInt32("countOfElement", context.Cart.Where(x => x.CustomerId == Convert.ToInt32(HttpContext.Session.GetInt32(Id))).Count());

                        ViewBag.b = "Purchase completed successfully.thank you.";
                        return RedirectToAction("Index");
                   }
                   else
                    {
                        ViewBag.b = "Balance in cridet card not enough.";
                        return RedirectToAction("Index");
                    }
                else
                {
                    ViewBag.b = "Credit card not exist.";
                    return RedirectToAction("OwnProfile");
                }
            
                ViewBag.b = "Please insert credit card number.";
             
            //var result = context.Customer.Where(x => x.Id == d.CustomerId).ToList();

            return View("ContactUs");


        }
        public IActionResult Login(string Email, string Password)
        {
            var e = context.Employee.Where(x => x.Email == Email && x.Password == Password);
            var epass = context.Employee.Where(x => x.Email == Email).Select(x => x.Password).FirstOrDefault();
            int Auth = context.Customer.Where(x => x.Email == Email && x.Password == Password).Select(x => x.Id).SingleOrDefault();
            int Auth1 = context.Customer.Where(x => x.Email == Email && x.Password == Password).Select(x => x.PhoneNumber).SingleOrDefault();
            var x = context.Customer.Where(x => x.Email == Email && x.Password == Password);

            if (Email != null && Password != null)
            {
                if (Email.Contains("@admin"))
                {

                    //ViewBag.User = context.Admin.Where(x => x.Email == Email && x.Password == Password);
                    var w = context.Admin.Where(x => x.Email == Email && x.Password == Password);
                    var pass = context.Admin.Where(x => x.Email == Email).Select(x => x.Password).FirstOrDefault();
                    if (w != null && Convert.ToString(pass) == Password)
                    {
                        ViewBag.User = x.Select(x => x.Fname).FirstOrDefault() + " " + x.Select(x => x.Lname).FirstOrDefault();
                        HttpContext.Session.SetString(AName, w.Select(x => x.Fname).FirstOrDefault() + " " + x.Select(x => x.Lname).FirstOrDefault());
                       
                        TempData[AName] = HttpContext.Session.GetString(AName);

                        //return RedirectToAction("Index");
                        return RedirectToAction("Index", "Admin");

                    }
                    else
                    {

                        ViewBag.M = "Sorry, your password or email was incorrect.";
                        return View();
                    }



                }
                else if (e != null && Convert.ToString(epass) == Password)
                    {
                        if (e.Select(x => x.DepartmentName).Contains( "employee"))
                        {
                            
                            HttpContext.Session.SetInt32(EId, e.Select(x=>x.Id).FirstOrDefault());
                            HttpContext.Session.SetString(EAName, e.Select(x => x.Fname).FirstOrDefault() + " " + x.Select(x => x.Lname).FirstOrDefault());
                           
                            TempData[EId] = HttpContext.Session.GetInt32(EId);

                            TempData[EAName] = HttpContext.Session.GetString(EAName);
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (e.Select(x => x.DepartmentName).Contains("accountant"))
                        {
                            HttpContext.Session.SetInt32(EId, e.Select(x => x.Id).FirstOrDefault());
                            HttpContext.Session.SetString(AEName, e.Select(x => x.Fname).FirstOrDefault() + " " + x.Select(x => x.Lname).FirstOrDefault());
                            
                            TempData[EId] = HttpContext.Session.GetString(EId);
                            TempData[AEName] = HttpContext.Session.GetString(AEName);
                            return RedirectToAction("Index", "Admin");
                        }
                       

                  
                //else
                //    {

                //        ViewBag.M = "Sorry, your password or email was incorrect.";
                //        return View();
                //    }
                  }
                else
                {
                    var w = context.Customer.Where(x => x.Email == Email && x.Password == Password).ToList();
                    var pass = context.Customer.Where(x => x.Email == Email).Select(x => x.Password).FirstOrDefault();
                    if (w != null && Convert.ToString(pass) == Password)
                    {

                        HttpContext.Session.SetInt32(Id, Auth);
                        HttpContext.Session.SetString(Name, x.Select(x => x.Fname).FirstOrDefault() + " " + x.Select(x => x.Lname).FirstOrDefault());
                        HttpContext.Session.SetInt32(PhNumber, Auth1);
                        HttpContext.Session.SetString(UEmail, Email);
                        HttpContext.Session.SetString(desc, x.Select(x => x.Description).FirstOrDefault());
                        //HttpContext.Session.SetString(address, x.Select(x => x.Address).FirstOrDefault());
                        //HttpContext.Session.SetString(subject, x.Select(x => x.Subject).FirstOrDefault());
                        HttpContext.Session.SetInt32("countOfElement", context.Cart.Where(x => x.CustomerId == Convert.ToInt32(HttpContext.Session.GetInt32(Id))).Count());

                        return RedirectToAction("Index");


                    }
                    else
                    {

                        ViewBag.M = "Sorry, your password or email was incorrect.";
                        return View();
                    }
                } 
                
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(Id);
            HttpContext.Session.Remove(PhNumber);
            HttpContext.Session.Remove(Name);
            HttpContext.Session.Remove(UEmail);
            HttpContext.Session.Remove(desc);
           //HttpContext.Session.Remove(address);
           // HttpContext.Session.Remove(subject);

            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");

            var table = context.Category.ToList();
            return View("Index",table);

        }
      
        [HttpPost]
        public IActionResult SaveContactUs(Contact model)
        {
            TempData[Id] = HttpContext.Session.GetString(Id);
            TempData["countOfElement"] = HttpContext.Session.GetInt32("countOfElement");
            model.Time = DateTime.Now;
            model.Approve = false;
            context.Contact.Add(model);
            
            context.SaveChanges();
            return RedirectToAction("ContactUs");
        }
        public async Task<IActionResult> AddToCart(int DesignId, Cart cart)
        {           
            TempData[Id] = HttpContext.Session.GetInt32(Id);
            TempData[Name] = HttpContext.Session.GetString(Name);
            TempData[PhNumber] = HttpContext.Session.GetInt32(PhNumber);
            TempData[UEmail] = HttpContext.Session.GetString(UEmail);
            TempData[desc] = HttpContext.Session.GetString(desc);
            //TempData[address] = HttpContext.Session.GetInt32(address);
            TempData[subject] = HttpContext.Session.GetString(subject);


            if (TempData[Id] != null)
            {
                if (ModelState.IsValid)
                {
                    cart.DesignId = DesignId;
                    cart.CustomerId = Convert.ToInt32(TempData[Id]);

                    var x = Convert.ToString(TempData["CatId"]) ;
                    context.Add(cart);
                    await context.SaveChangesAsync();          
                    HttpContext.Session.SetInt32("countOfElement", context.Cart.Where(x => x.CustomerId == Convert.ToInt32(HttpContext.Session.GetInt32(Id))).Count());

                    return RedirectToAction("Index");
                }
                ////ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Description", cart.CustomerId);
                ////ViewData["DesignId"] = new SelectList(_context.Design, "Id", "Image", cart.DesignId);
                return View(cart);
            }
            else
            {
                ViewBag.Login = "Please, Login First";
                return View("Login"); }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
