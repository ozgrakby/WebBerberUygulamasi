using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class ServiceView
    {
        public int ServiceID { get; set; }
        [Required]
        [Display(Name = "Hizmet Adı ")]
        public string ServiceName { get; set; }
        [Required]
        [Display(Name = "Hizmet Ücreti ")]
        public int ServicePrice { get; set; }
        [Required]
        [Display(Name = "Hizmet Süresi ")]
        public int ServiceTime { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
