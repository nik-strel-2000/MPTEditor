using Microsoft.EntityFrameworkCore;
namespace MPTEditor.Models
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Users> Users { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<PaymentRegister> Payment_register { get; set; }
        public DbSet<Listeners> Listeners { get; set; }
        public DbSet<Contracts> Contracts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options){}
    }
}
