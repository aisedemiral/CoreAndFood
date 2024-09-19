using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c=new Context();
        public IActionResult Index(int page=1)
        {
   
            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values=(from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v1 = values;
            return View();
        } 
        [HttpPost]
        public IActionResult AddFood(AddProduct fd)
        {
            Food f = new Food();
            if(fd.ImageURL!=null)
            {
                var extension = Path.GetExtension(fd.ImageURL.FileName);
                var newImageName=Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images_2/",newImageName);
                var stream=new FileStream(location, FileMode.Create);
                fd.ImageURL.CopyTo(stream);
                f.ImageURL = location;
            }
            f.Name= fd.Name;
            f.Price = fd.Price;
            f.Description = fd.Description;
            f.CategoryID = fd.CategoryID;
            f.Stock = fd.Stock;
            foodRepository.AddT(f);
            return RedirectToAction("Index");
        }  
        public IActionResult DeleteFood(int id)
        {
            foodRepository.DeleteT(new Food { FoodID = id});
            return RedirectToAction("Index");
        }
        public IActionResult GetFood(int id)
        {
            var x=foodRepository.GetT(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Food fd = new Food()
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ImageURL = x.ImageURL
            };
            return View(fd);
        }
        public IActionResult UpdateFood(Food fd)
        {
            var x = foodRepository.GetT(fd.FoodID);
            x.Name= fd.Name;
            x.Description= fd.Description;
            x.Price= fd.Price;
            x.Stock= fd.Stock;
            x.ImageURL= fd.ImageURL;
            x.CategoryID= fd.CategoryID;
            foodRepository.UpdateT(x);
            return RedirectToAction("Index");
        }
    }
}
