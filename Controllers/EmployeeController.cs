using Microsoft.AspNetCore.Mvc;

namespace WebBerberUygulamasi.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
