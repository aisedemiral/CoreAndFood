using CoreAndFood.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        Context c=new Context();
        [AllowAnonymous] //Sitemizde bütün Controller ve bu Controllerların Viewlarını Authentication işlemine tabi tuttuk ki kullanıcı girişi yapılmadan panelimizdeki herhangi bir sayfaya yönlendirmesin.Ancak biz program.cs dosyasında bunu her Controller a yaptığımız için Login Controller da bundan etkilendi ve Login sayfamız da açılmadı.
        //Ancak [AllowAnonymus] attribute ü ile kullanıcı girişi yapılmadan göstermek istediğimiz sayfaları görüntülememizi sağlıyor.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }       
        [AllowAnonymous]
        [HttpPost]
        public async  Task<IActionResult> Index(Admin p)
        {
            var datavalue=c.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            if(datavalue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName)
                };
                var useridentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
