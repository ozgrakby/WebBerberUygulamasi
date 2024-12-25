using Microsoft.AspNetCore.Mvc;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("sessID");
            HttpContext.Session.Remove("sessDisplay");
            HttpContext.Session.Remove("sessRole");
            return RedirectToAction("Index", "Home");
        }
    }
}
