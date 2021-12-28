using Microsoft.AspNetCore.Mvc;
using POSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Controllers
{
    public class CategoryController : Controller
    {
        private readonly POSaleContext _dbcontext;
        public CategoryController(POSaleContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.ListCategory = _dbcontext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category cat)
        {
            try
            {
                _dbcontext.Categories.Add(cat);
                _dbcontext.SaveChanges();
                TempData["SMessage"] = "Category Added Succesfully.";
            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Adding Please Try Again!!";
            }

            return RedirectToAction(nameof(CategoryController.AllCategories));
        }
        public IActionResult AllCategories()
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];
            IList<Category> ICategory = _dbcontext.Categories.ToList();
            return View(ICategory);
        }
        [HttpGet]
        public IActionResult DetailCategory(int Id)
        {
            try
            {
                Category category = _dbcontext.Categories.Find(Id);
                return View(category);
            }
            catch (Exception)
            {
                TempData["EMessage"] = "Some Error Occuried While Fatching Please Try Again!!";
            }
            return RedirectToAction(nameof(CategoryController.AllCategories));
        }
        [HttpGet]
        public IActionResult EditCategory(int Id)
        {
            try
            {
                TempData["SMessage"] = "Product Editing Succesfully.";
                Category category = _dbcontext.Categories.Find(Id);
                return View(category);
            }
            catch (Exception)
            {
                TempData["EMessage"] = "Some Error Occuried While Modifing Please Try Again!!";
                return View();
            }
        }
        [HttpPost]
        public IActionResult EditCategory(Category cat)
        {
            try
            {
                _dbcontext.Categories.Update(cat);
                _dbcontext.SaveChanges();
                TempData["SMessage"] = "Data Updated Successfully";
            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occuried While Modifing Please Try Again!!";
            }
            return RedirectToAction(nameof(CategoryController.AllCategories), new { cat.CategoryId });
        }
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var objCat = _dbcontext.Categories.Find(id);
                if (objCat != null)
                {
                    _dbcontext.Categories.Remove(objCat);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Category Deleted Successfully";
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
            return RedirectToAction(nameof(CategoryController.AllCategories));
        }
    }
}
