using System.ComponentModel.DataAnnotations;

namespace WebBerberUygulamasi.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Kullanıcının adı girilmesi zorunludur.")]
        [MaxLength(50, ErrorMessage = "Kullanıcının adı 50 karakterden fazla olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcının soyadı girilmesi zorunludur.")]
        [MaxLength(50, ErrorMessage = "Kullanıcının soyadı 50 karakterden fazla olamaz.")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Email girilmesi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Telefon numarası girilmesi zorunludur.")]
        [Phone(ErrorMessage = "Geçersiz bir telefon numarası.")]
        public string UserPhone { get; set; }

        public int UserRole {  get; set; }

        [Required(ErrorMessage = "Kullanıcının bir parolo girmesi zorunludur.")]
        [MinLength(6, ErrorMessage = "Parola 6 karakterden uzun olmalıdır.")]
        [MaxLength(32, ErrorMessage = "Parola 32 karakterden uzun olmalıdır.")]
        public string UserPassword { get; set; }
    }
}
