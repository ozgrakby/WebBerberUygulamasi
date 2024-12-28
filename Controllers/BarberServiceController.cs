using Microsoft.AspNetCore.Mvc;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class BarberServiceController : Controller
    {
        ShopContext sc = new ShopContext();
        public IActionResult Index()
        {
            int UserID = sc.Users.Where(x => x.UserID == Convert.ToInt16(new AESEncryptionService().Decrypt(HttpContext.Session.GetString("sessID")))).First().UserID;
            if (UserID == null)
            {
                return NotFound();
            }

            var services = sc.Services.Where(x => x.UserID == UserID).ToList();

            if (services.Count == 0)
            {
                return RedirectToAction(nameof(Create), new { id = UserID });
            }
            return View(services);
        }

        public IActionResult Create(int id)
        {
            var user = sc.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ServiceName,ServicePrice,ServiceTime,UserID")] ServiceView serviceView)
        {
            if (ModelState.IsValid)
            {
                Service service = new Service();
                service.ServiceName = serviceView.ServiceName;
                service.ServicePrice = serviceView.ServicePrice;
                service.ServiceTime = serviceView.ServiceTime;
                service.UserID = serviceView.UserID;
                sc.Services.Add(service);
                sc.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = service.UserID });
            }
            return View(serviceView);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = sc.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }
            var serviceView = new ServiceView();
            serviceView.ServiceID = service.ServiceID;
            serviceView.ServiceName = service.ServiceName;
            serviceView.ServicePrice = service.ServicePrice;
            serviceView.ServiceTime = service.ServiceTime;
            serviceView.UserID = service.UserID;
            return View(serviceView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ServiceID, ServiceName,ServicePrice,ServiceTime,UserID")] ServiceView serviceView)
        {
            var service = sc.Services.Find(serviceView.ServiceID);
            if (service is null)
            {
                return NotFound();
            }
            service.ServiceName = serviceView.ServiceName;
            service.ServicePrice = serviceView.ServicePrice;
            service.ServiceTime = serviceView.ServiceTime;
            if (ModelState.IsValid)
            {
                sc.Update(service);
                sc.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(serviceView);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = sc.Services.FirstOrDefault(x => x.ServiceID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = sc.Services.Find(id);
            int UserID = service.UserID;
            if (service != null)
            {
                sc.Services.Remove(service);
                sc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
