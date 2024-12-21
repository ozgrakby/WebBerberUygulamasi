using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Required]
        [Display(Name = "Hizmet Adı ")]
        public string ServiceName { get; set; }
        [Required]
        [Display(Name = "Hizmet Ücreti ")]
        public double ServicePrice { get; set; }
        [Required]
        [Display(Name = "Hizmet Süresi ")]
        public int ServiceTime { get; set; }
        [Required]
        public int EmployeeID {  get; set; }
        [Required]
        public Employee Employee { get; set; }
    }
}
