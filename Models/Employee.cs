using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        [MaxLength(450)]
        public string UserID {  get; set; }
        [Required]
        public IdentityUser User { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
