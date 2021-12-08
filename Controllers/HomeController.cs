using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POSale.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly POSaleContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, POSaleContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        #region Defualt
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion 

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer Cust)
        {
            try
            {
                _dbcontext.Customers.Add(Cust);
                _dbcontext.SaveChanges();
                //ViewBag.SMessage = "Customer Added Succesfully.";
                TempData["SMessage"] = "Customer Added Succesfully.";
            }
            catch(Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Adding Please Try Again!!";
            }
            
            return RedirectToAction(nameof(HomeController.AllCustomer));
        }
        public IActionResult AllCustomer()
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];
            IList<Customer> ICustomer = _dbcontext.Customers.ToList();
            return View(ICustomer);
        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            Customer objCust = _dbcontext.Customers.Find(id);
            return View(objCust);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            try
            {
                _dbcontext.Customers.Attach(customer);
                var Entry = _dbcontext.Entry(customer);
                Entry.State = EntityState.Modified;
                _dbcontext.SaveChanges();
                TempData["SMessage"] = "Customer Edit Succesfully.";
            }
            catch(Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Editing Please Try Again!!";
            }
            return RedirectToAction(nameof(HomeController.AllCustomer), new { customer.CustomerId});
        }
        public IActionResult Customerdetail(int id)
        {
            try
            {
                Customer ObjItemCategory = _dbcontext.Customers.Find(id);
                return View(ObjItemCategory);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public IActionResult DeleteCustomer()
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}
