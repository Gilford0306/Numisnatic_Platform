using Microsoft.EntityFrameworkCore;
using Numisnatic_Platform.Class;

namespace ProductEntity
{
    public class MyApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Monet> Monets { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N6GODSK;Database=NumsBase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}