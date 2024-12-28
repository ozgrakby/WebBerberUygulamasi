using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class AppointmentView
    {
        [Required]
        [Display(Name = "Randevu Zamanı ")]
        public DateTime AppointmentTime { get; set; }
        [Required]
        public int ServiceID { get; set; }
        [Required]
        public int UserID { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
