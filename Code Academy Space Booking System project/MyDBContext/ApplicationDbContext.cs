using Code_Academy_Space_Booking_System_project.Model;
using Microsoft.EntityFrameworkCore;

namespace Code_Academy_Space_Booking_System_project.MyDBContext
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-ISH7TNU; " +
                "Initial Catalog=CodeAcademyBookingDB; " +
                "Integrated Security=True;"
                );
        }

        public DbSet<Space> Spaces { get; set; }
        public DbSet<Booking> Book { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bill> Bills { get; set; }


    }
}
