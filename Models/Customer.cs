using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(450)]
        public string UserID { get; set; }
        [Required]
        public IdentityUser User { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
