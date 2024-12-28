using Microsoft.AspNetCore.Mvc;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class BarberAppointmentController : Controller
    {
        ShopContext sc = new ShopContext();
        public IActionResult Index()
        {
            int UserID = sc.Users.Where(x => x.UserID == Convert.ToInt16(new AESEncryptionService().Decrypt(HttpContext.Session.GetString("sessID")))).First().UserID;
            var appointments = sc.Appointments.Where(x => x.UserID == UserID).OrderByDescending(x => x.AppointmentTime).ToList();
            var query = from appointment in sc.Appointments
                        join service in sc.Services on appointment.ServiceID equals service.ServiceID
                        join user in sc.Users on appointment.UserID equals user.UserID
                        orderby appointment.AppointmentTime descending
                        select new AppointmentList(appointment.AppointmentID, service.ServiceName, user.UserName, user.UserSurname, appointment.AppointmentTime, appointment.AppointmentConfirmed);
            return View(query);
        }
        public IActionResult Confirm(int id)
        {
            var appointment = sc.Appointments.FirstOrDefault(x => x.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }
            appointment.AppointmentConfirmed = true;
            sc.Appointments.Update(appointment);
            sc.SaveChanges();
            return RedirectToAction(nameof(Index));
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
    }
}
