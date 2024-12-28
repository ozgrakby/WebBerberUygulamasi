using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        [Required(ErrorMessage = "Dükkan için açılış saati girilmesi zorunludur.")]
        [Display(Name = "Açılış zamanı")]
        public TimeSpan ShopOpening { get; set; }
        [Required(ErrorMessage = "Dükkan için kapanış saati girilmesi zorunludur.")]
        [Display(Name = "Kapanış zamanı")]
        public TimeSpan ShopClosing { get; set; }
    }
}
