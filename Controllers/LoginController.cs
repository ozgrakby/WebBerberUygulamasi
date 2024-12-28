using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class LoginController : Controller
    {
        ShopContext sc = new ShopContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginModel lm)
        {
            var isUser = sc.Users.FirstOrDefault(x => x.UserEmail == lm.UserEmail);
            if (isUser is not null)
            {
                lm.UserPassword = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(lm.UserPassword)));

                
                if(isUser.UserPassword == lm.UserPassword)
                {
                    HttpContext.Session.SetString("sessID", new AESEncryptionService().Encrypt(Convert.ToString(isUser.UserID)));
                    HttpContext.Session.SetString("sessDisplay", isUser.UserEmail);
                    string seesRole = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Convert.ToString(isUser.UserRole))));
                    HttpContext.Session.SetString("sessRole", seesRole);
                    TempData["msj"] = isUser.UserName + " " + isUser.UserSurname + " kullanıcısı giriş yaptı.";
                    return RedirectToAction("Success");
                }
                else
                {
                    TempData["msj"] = "Şifre yanlış.";
                    return RedirectToAction("Failed");
                }
            }
            else
            {
                TempData["msj"] = "Böyle bir kullanıcı bulunamadı.";
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
