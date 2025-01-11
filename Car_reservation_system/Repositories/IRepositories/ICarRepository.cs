using Car_reservation_system.Controllers;
using Car_reservation_system.Models;

namespace Car_reservation_system.Repositories.IRepositories
{
    public interface ICarRepository : IRepository<Car, CarModelDto>
    {
        Task AddCarAsync(CarModelDto carDto);
        Task UpdateAsync(CarModelDto carDto);
        Task DeleteCarAsync(int carId);

        Task RentCarAsync(int userId, int carId);
        Task<IEnumerable<CarModelDto>> RentedCarsByUser(int userId);
        Task ReturnCar(int userId, int carId);
    }
}
