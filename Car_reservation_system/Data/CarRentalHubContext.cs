using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_reservation_system.Models;


namespace Car_reservation_system.Data
{
    public class CarRentalHubContext : DbContext
    {
        public CarRentalHubContext(DbContextOptions<CarRentalHubContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Car_reservation_system.Models.Car> CarInfoModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienie precyzji i skali dla kolumny 'Price'
            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)"); // Dla przykładu, ustaw precyzję na 18 i skalę na 2 (możesz dostosować do swoich potrzeb)
        }
    }
}