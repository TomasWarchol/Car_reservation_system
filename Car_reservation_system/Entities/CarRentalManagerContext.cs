using Car_reservation_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_reservation_system.Entities
{
    public class CarRentalManagerContext : DbContext
    {
        public CarRentalManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RentCarInfo> RentInfo { get; set; }
        public DbSet<Role> Roles { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RentCarInfo>()
                .HasIndex(u => u.UserId)
                .IsUnique(false);

            modelBuilder.Entity<RentCarInfo>()
                .HasIndex(c => c.CarId)
                .IsUnique(false);
        }
    }
}
