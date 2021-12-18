using Microsoft.AspNetCore.Mvc;
using POSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Controllers
{
    public class ProductController : Controller
    {
        private readonly POSaleContext _dbcontext;
        public ProductController(POSaleContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product pro)
        {
            try
            {
                _dbcontext.Products.Add(pro);
                _dbcontext.SaveChanges();
                TempData["SMessage"] = "Product Added Succesfully.";
            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Adding Please Try Again!!";
            }

            return RedirectToAction(nameof(ProductController.AllProducts));
        }
        public IActionResult AllProducts()
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];
            IList<Product> IProduct = _dbcontext.Products.ToList();
            return View(IProduct);
        }
    }
}
