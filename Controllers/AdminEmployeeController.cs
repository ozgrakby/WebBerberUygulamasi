using Microsoft.AspNetCore.Mvc;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
