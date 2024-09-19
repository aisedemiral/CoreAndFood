using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        //[Authorize]
        public IActionResult Index(string p)
        {
           if(!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(x=>x.CategoryName.Contains(p)));
            }
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category cat)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.AddT(cat);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.GetT(id);
            Category ct = new Category()
            {
                CategoryName=x.CategoryName,
                CategoryDescription=x.CategoryDescription,
                CategoryID=x.CategoryID
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category cat)
        {
            var x=categoryRepository.GetT(cat.CategoryID);
            x.CategoryName = cat.CategoryName;
            x.CategoryDescription = cat.CategoryDescription;
            x.Status = true;
            categoryRepository.UpdateT(x);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.GetT(id);
            x.Status=false;
            categoryRepository.UpdateT(x);
            return RedirectToAction("Index");
        }
    }
}
