using Car_reservation_system.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Car_reservation_system
{
    public class CarRentalSeeder
    {
        private readonly CarRentalManagerContext _dbContext;

        public CarRentalSeeder(CarRentalManagerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _dbContext.Database.Migrate();
            }

            if (_dbContext.Database.CanConnect())
            {
                

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Cars.Any())
                {
                    var cars = GetCars();
                    _dbContext.Cars.AddRange(cars);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Users.Any())
                {
                    var admin = GetAdmin();
                    var user = GetUser();
                    _dbContext.Users.Add(admin);
                    _dbContext.SaveChanges();
                }

            }
        }

        private User GetAdmin()
        {
            var admin = new User()
            {
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBRD56y8qwwcO418F+27FZzHwdH+SbDfGE6/baUq4afdTqalI/JzR5dKpvchm+mgVg==",
                RoleId = 3
            };
            return admin;
        }

        private User GetUser()
        {
            var user = new User()
            {
                FirstName = "tom",
                LastName = "war",
                Email = "222@op.pl",
                PasswordHash = "AQAAAAIAAYagAAAAEESv8rvZdVtbAFJF4qDKT98TBAZDBLnleKFtBBAnqr+4yfvY3QfdZcDHLnnbGFNZKw==",
                RoleId = 1
            };
            return user;
        }


        private IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>()
            {
            };

            return cars;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
    }
}
