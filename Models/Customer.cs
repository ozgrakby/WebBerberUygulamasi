using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public User user { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
