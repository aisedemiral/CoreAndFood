using CoreAndFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CoreAndFood.Models;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ColIndex()
        {
            return View();
        }
        public IActionResult FoodIndex()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<C2> FoodList()
        {
            List<C2> cs2 = new List<C2>();
            using(var c=new Context())
            {
                cs2 = c.Foods.Select(x => new C2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(Prolist());
        }        

        public List<C1> Prolist()
        {
            List<C1> cs=new List<C1>();
            cs.Add(new C1()
            {
                proname = "Computer",
                stock = 80
            });           
            cs.Add(new C1()
            {
                proname = "LCD",
                stock = 60
            }); 
            cs.Add(new C1()
            {
                proname = "USB Disc",
                stock = 110
            });
            return cs;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();
            var vari1 = c.Foods.Count();
            ViewBag.d1=vari1;

            var vari2 = c.Categories.Count();
            ViewBag.d2 = vari2;

            var foid=c.Categories.Where(x=>x.CategoryName=="Fruits").Select(y=>y.CategoryID).FirstOrDefault();
            ViewBag.d=foid;
            var vari3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = vari3;

            var vari4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = vari4;

            var vari5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = vari5;

            var vari6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Legumes").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = vari6;

            var vari7 = c.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.Name).FirstOrDefault();
            ViewBag.d7 = vari7;

            var vari7_1 = c.Foods.OrderByDescending(x => x.Stock).Select(y=>y.Stock).FirstOrDefault();
            ViewBag.d7_1 = vari7_1;

            var vari8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = vari8;

            var vari8_1 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Stock).FirstOrDefault();
            ViewBag.d8_1 = vari8_1;

            var vari9 = c.Foods.Average(x=>x.Price).ToString("0.00");
            ViewBag.d9 = vari9;

            var vari10 = c.Categories.Where(x=>x.CategoryName=="Fruits").Select(y=>y.CategoryID).FirstOrDefault();
            var vari10_1 = c.Foods.Where(y=>y.CategoryID==vari10).Sum(x=>x.Stock);
            ViewBag.d10 = vari10_1;

            var vari11 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var vari11_1 = c.Foods.Where(y => y.CategoryID == vari11).Sum(x => x.Stock);
            ViewBag.d11 = vari11_1;

            var vari12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = vari12;

            var vari12_1 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Price).FirstOrDefault();
            ViewBag.d12_1 = vari12_1;
            return View();
        }
    }
}
