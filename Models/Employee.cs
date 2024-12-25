using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public int UserID {  get; set; }
        [Required]
        public User user { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
