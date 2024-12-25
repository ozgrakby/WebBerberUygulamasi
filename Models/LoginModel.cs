using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email girilmesi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir email")]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Kullanıcının bir parolo girmesi zorunludur.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
