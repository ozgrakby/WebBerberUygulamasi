﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Randevu Zamanı ")]
        public DateTime AppointmentTime { get; set; }
        [Required]
        [Display(Name = "Randevu Onay ")]
        public bool AppointmentConfirmed { get; set; }
        [Required]
        public int ServiceID { get; set; }
        [Required]
        public Service Service { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}
