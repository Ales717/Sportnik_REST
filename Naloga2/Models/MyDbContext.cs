using Microsoft.EntityFrameworkCore;

namespace Naloga2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Tekmovanje> tekmovanje { get; set; }
        public DbSet<Rezultati> rezultati { get; set; }
        public DbSet<Users> users { get; set; }

    }
}
