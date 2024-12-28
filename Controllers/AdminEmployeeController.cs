using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminEmployeeController : Controller
    {
        ShopContext sc = new ShopContext();
        public IActionResult Index()
        {
            return View(sc.Users.Where(x => x.UserRole == 2).ToList());
        }

        public IActionResult Demote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.UserRole = 1;
                sc.Users.Update(user);
                sc.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Services(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = sc.Services.Where(x => x.UserID == id).ToList();

            if (services.Count == 0)
            {
                return RedirectToAction(nameof(AddService), new { id = id });
            }
            return View(services);
        }

        public IActionResult AddService(int id)
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
        public IActionResult AddService([Bind("ServiceName,ServicePrice,ServiceTime,UserID")] ServiceView serviceView)
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
                return RedirectToAction(nameof(Services), new { id = service.UserID });
            }
            return View(serviceView);
        }

        public IActionResult EditService(int id)
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
        public IActionResult EditService(int id, [Bind("ServiceID, ServiceName,ServicePrice,ServiceTime,UserID")] ServiceView serviceView)
        {
            var service = sc.Services.Find(serviceView.ServiceID);
            if(service is null)
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

                return RedirectToAction(nameof(Services), new { id = service.UserID });
            }
            return View(serviceView);
        }

        public IActionResult DeleteService(int? id)
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

        [HttpPost, ActionName("DeleteService")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedService(int id)
        {
            var service = sc.Services.Find(id);
            int UserID = service.UserID;
            if (service != null)
            {
                sc.Services.Remove(service);
                sc.SaveChanges();
            }

            return RedirectToAction(nameof(Services), new {id = UserID});
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserID,UserName,UserSurname,UserEmail,UserPhone,UserRole,UserPassword")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                sc.Update(user);
                sc.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Users.FirstOrDefault(x => x.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = sc.Users.Find(id);
            if (user != null)
            {
                sc.Users.Remove(user);
                sc.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
