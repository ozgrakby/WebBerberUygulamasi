using Microsoft.AspNetCore.Identity;

namespace WebBerberUygulamasi.Models
{
    public class LoginModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
