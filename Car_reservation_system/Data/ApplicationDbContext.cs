using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Car_reservation_system.Data
{

    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.Reservation> Reservations { get; set; }
    }

}
