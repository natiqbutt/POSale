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
            ViewBag.ListCategories = _dbcontext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product pro)
        {
            try
            {
                if (pro.ProductCategory == null)
                {
                    pro.ProductCategory = 0;
                }
                pro.CreatedBy = "Theta";
                pro.CreatedDate = DateTime.Now;
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
            try
            {
                ViewBag.SMessage = TempData["SMessage"];
                ViewBag.EMessage = TempData["EMessage"];
                IList<Product> IProduct = _dbcontext.Products.ToList();
                return View(IProduct);
            }
            catch
            {
                ViewBag.EMessage = "Error occurs while fatching data.";
            }
            return View();
        }
        [HttpGet]
        public IActionResult DetailProduct(int Id)
        {
            try
            {
                Product product = _dbcontext.Products.Find(Id);
                return View(product);
            }
            catch (Exception)
            {
                TempData["EMessage"] = "Some Error Occuried While Fatching Please Try Again!!";
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditProduct(int Id)
        {
            try
            {
                TempData["SMessage"] = "Product Editing Succesfully.";
                Product product = _dbcontext.Products.Find(Id);
                return View(product);
            }
            catch (Exception)
            {
                TempData["EMessage"] = "Some Error Occuried While Modifing Please Try Again!!";
                return View();
            }
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            try
            {
                product.ModifyBy = "System";
                product.ModifyDate = DateTime.Now;
                _dbcontext.Products.Update(product);
                _dbcontext.SaveChanges();
                TempData["SMessage"] = "Data Updated Successfully";
            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Modifing Please Try Again!!";
            }
            return RedirectToAction(nameof(ProductController.AllProducts), new { product.ProductId });
        }
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var objCat = _dbcontext.Products.Find(id);
                if (objCat != null)
                {
                    _dbcontext.Products.Remove(objCat);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Deleted Successfully";
                }
                else
                {
                    TempData["EMessage"] = "Category not found";
                }
            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some error occured";
            }
            return RedirectToAction(nameof(ProductController.AllProducts));
        }
    }
}