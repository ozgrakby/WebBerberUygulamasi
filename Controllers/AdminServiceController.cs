using Microsoft.AspNetCore.Mvc;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
