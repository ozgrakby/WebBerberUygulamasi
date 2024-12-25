using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class RegisterController : Controller
    {
        ShopContext sc = new ShopContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            var isUser = sc.Users.FirstOrDefault(x=>x.UserEmail == user.UserEmail);
            if (isUser is null)
            {
                user.UserRole = 1;
                var md5 = MD5.Create();
                user.UserPassword = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword)));

                if (ModelState.IsValid)
                {
                    sc.Users.Add(user);
                    sc.SaveChanges();
                }
                TempData["msj"] = isUser.UserName + " " + isUser.UserSurname + " kullanıcısı kayıt oldu.";
                return RedirectToAction("Success");
            }
            else {
                TempData["msj"] = "Böyle bir kullanıcı zaten mevcut.";
                return RedirectToAction("Failed");
            }
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failed()
        {
            return View();
        }
    }
}
