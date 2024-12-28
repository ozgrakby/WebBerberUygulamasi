using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class UserAppointmentController : Controller
    {
        ShopContext sc = new ShopContext();

        public IActionResult Index()
        {
            int UserID = sc.Users.Where(x => x.UserID == Convert.ToInt16(new AESEncryptionService().Decrypt(HttpContext.Session.GetString("sessID")))).First().UserID;
            var appointments = sc.Appointments.Where(x=>x.UserID == UserID).OrderByDescending(x=> x.AppointmentTime).ToList();
            var query = from appointment in sc.Appointments
                        join service in sc.Services on appointment.ServiceID equals service.ServiceID
                        join user in sc.Users on service.UserID equals user.UserID
                        orderby appointment.AppointmentTime descending
                        select new AppointmentList(appointment.AppointmentID, service.ServiceName, user.UserName, user.UserSurname, appointment.AppointmentTime, appointment.AppointmentConfirmed);
            return View(query);
        }

        public IActionResult Delete(int id)
        {
            var appointment = sc.Appointments.FirstOrDefault(x => x.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }
            sc.Appointments.Remove(appointment);
            sc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateAppointment()
        {
            var viewModel = new AppointmentView
            {
                Users = sc.Users.Where(x=>x.UserRole == 2).Select(s => new SelectListItem
                {
                    Value = s.UserID.ToString(),
                    Text = s.UserName + " " + s.UserSurname
                }),
                Services = Enumerable.Empty<SelectListItem>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAppointment(AppointmentView model)
        {
            bool IsValid = true;
            var shop = sc.Shop.ToList().First();

            if (model.AppointmentTime <= DateTime.Now) {
                IsValid = false;
                TempData["msj"] = "Geçmiş tarih için randevu alamazsın.";
            }
            else
            {
                var service = sc.Services.Where(x => x.ServiceID == model.ServiceID).First();

                if (model.AppointmentTime.DayOfWeek == DayOfWeek.Saturday || model.AppointmentTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    IsValid = false;
                    TempData["msj"] = "Dükkanımızın kapalı olduğu cumartesi ve pazar günleri için randevu alamazsın.";
                }
                else
                {
                    if (model.AppointmentTime.TimeOfDay < shop.ShopOpening || model.AppointmentTime.TimeOfDay.Add(TimeSpan.FromMinutes(service.ServiceTime)) > shop.ShopClosing)
                    {
                        IsValid = false;
                        TempData["msj"] = "Dükkanımızın kapalı olduğu saatler için randevu alamazsın.";
                    }
                    else
                    {
                        var appointmens = sc.Appointments.Where(x => x.AppointmentTime.Year.Equals(model.AppointmentTime.Year) && x.AppointmentTime.Month.Equals(model.AppointmentTime.Month) && x.AppointmentTime.Day.Equals(model.AppointmentTime.Day)).ToList();

                        if (appointmens.Count != 0)
                        {
                            foreach (var appointment in appointmens)
                            {
                                var appService = sc.Services.Where(x => x.ServiceID == appointment.ServiceID).First();
                                if (appService.UserID != service.UserID)
                                {
                                    continue;
                                }
                                if (model.AppointmentTime.TimeOfDay < appointment.AppointmentTime.TimeOfDay)
                                {
                                    if (model.AppointmentTime.TimeOfDay.Add(TimeSpan.FromMinutes(service.ServiceTime)) > appointment.AppointmentTime.TimeOfDay)
                                    {
                                        IsValid = false;
                                        TempData["msj"] = "Seçmiş olduğunuz saatler içerisinde berberimizin başka bir randevusu bulunmaktadır. Saat: " + appointment.AppointmentTime.TimeOfDay.Subtract(TimeSpan.FromMinutes(service.ServiceTime + 10)).ToString() + " için randevu alabilirsiniz.";
                                    }
                                }
                                else if (model.AppointmentTime > appointment.AppointmentTime)
                                {
                                    if (appointment.AppointmentTime.TimeOfDay.Add(TimeSpan.FromMinutes(appService.ServiceTime)) > model.AppointmentTime.TimeOfDay)
                                    {
                                        IsValid = false;
                                        TempData["msj"] = "Seçmiş olduğunuz saatler içerisinde berberimizin başka bir randevusu bulunmaktadır. Saat: " + appointment.AppointmentTime.TimeOfDay.Add(TimeSpan.FromMinutes(appService.ServiceTime + 10)).ToString() + " için randevu alabilirsiniz.";
                                    }
                                }
                                else
                                {
                                    IsValid = false;
                                }
                            }
                        }
                    }                    
                }                
            }

            if (IsValid)
            {
                var appointment = new Appointment
                {
                    AppointmentTime = model.AppointmentTime,
                    AppointmentConfirmed = false,
                    ServiceID = model.ServiceID,
                    UserID = Convert.ToInt32(new AESEncryptionService().Decrypt(HttpContext.Session.GetString("sessID")))
                };

                sc.Add(appointment);
                sc.SaveChanges();

                return RedirectToAction("Index");
            }

            model.Users = sc.Users.Select(s => new SelectListItem
            {
                Value = s.UserID.ToString(),
                Text = s.UserName + s.UserSurname
            });

            model.Services = sc.Services.Select(s => new SelectListItem
            {
                Value = s.ServiceID.ToString(),
                Text = s.ServiceName
            });

            return View(model);
        }

        [HttpGet]
        public JsonResult GetServicesByUser(int UserID) 
        {
            var Services = sc.Services
            .Where(s => s.UserID == UserID)
            .Select(s => new SelectListItem
            {
                Value = s.ServiceID.ToString(),
                Text = s.ServiceName
            })
            .ToList();

            return Json(Services);
        }
    }
}
