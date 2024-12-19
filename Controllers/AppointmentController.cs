using Microsoft.AspNetCore.Mvc;

namespace WebBerberUygulamasi.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
