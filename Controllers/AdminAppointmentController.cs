﻿using Microsoft.AspNetCore.Mvc;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminAppointmentController : Controller
    {
        ShopContext sc = new ShopContext();

        public IActionResult Index()
        {
            var appointments = sc.Appointments.OrderByDescending(x => x.AppointmentTime).ToList();
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
    }
}
