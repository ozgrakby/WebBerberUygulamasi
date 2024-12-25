using Microsoft.EntityFrameworkCore;

namespace WebBerberUygulamasi.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=WebBerber;Trusted_Connection=True;");
        }
    }
}
