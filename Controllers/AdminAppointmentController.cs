using Microsoft.AspNetCore.Mvc;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminAppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
