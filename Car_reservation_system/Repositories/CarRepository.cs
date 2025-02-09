﻿using AutoMapper;
using Car_reservation_system.Controllers;
using Car_reservation_system.Exceptions;
using Car_reservation_system.Models;
using Car_reservation_system.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Car_reservation_system.Repositories
{
    public class CarRepository : Repository<Car, CarModelDto>, ICarRepository
    {
        private readonly CarRentalManagerContext _context;
        private readonly IMapper _mapper;

        public CarRepository(CarRentalManagerContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarModelDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await AddAsync(car);
        }

        public async Task UpdateAsync(CarModelDto carDto)
        {
            var car = _context
                .Cars
                .SingleOrDefault(x => x.Id == carDto.Id) ?? throw new NotFoundException("Auto nie znalezione.");

            car.Category = carDto.Category;
            car.Make = carDto.Make;
            car.Model = carDto.Model;
            car.Engine = carDto.Engine??= 1;
            car.Horsepower = carDto.Horsepower ??= 100;
            car.Year = carDto.Year??=2000;
            car.Seats = carDto.Seats ??= 5;
            car.Doors = carDto.Doors ??= 5;
            car.Fuel = carDto.Fuel;
            car.Transmission = carDto.Transmission ??= "Manualna";
            car.Description = carDto.Description;
            car.Available = carDto.Available;
            car.ImageUrl= carDto.ImageUrl;

            _context.Cars.Update(car);
            await Task.CompletedTask;
        }

        public async Task DeleteCarAsync(int carId)
        {
            var car = _context.Cars.SingleOrDefault(x => x.Id == carId) ?? throw new NotFoundException("Auto nie znalezione");
            await DeleteAsync(car);
        }

        public async Task RentCarAsync(int userId, int carId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId) ?? throw new NotFoundException("Użytkownik nie odnaleziony");
            var car = _context.Cars.SingleOrDefault(c => c.Id == carId) ?? throw new NotFoundException("Auto nie znalezione");

            car.Available = false;

            var rentInfo = new RentCarInfo()
            {
                UserId = user.Id,
                CarId = car.Id,
                IsGivenBack = false
            };

            _context.RentInfo.Add(rentInfo);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<CarModelDto>> RentedCarsByUser(int userId)
        {
            var user = _context
                .Users
                .SingleOrDefault(u => u.Id == userId) ?? throw new NotFoundException("Użytkownik nie odnaleziony");

            var rentedCarInfo = _context
                .RentInfo
                .Include(c => c.Car)
                .Where(u => u.UserId == user.Id && u.IsGivenBack == false)
                .ToList();

            var carsDtosList = new List<CarModelDto>();
            if (rentedCarInfo.Any())
            {
                foreach (var car in rentedCarInfo)
                {
                    carsDtosList.Add(_mapper.Map<CarModelDto>(car.Car));
                }
                return await Task.FromResult(carsDtosList);
            }
            return null;
        }

        public async Task ReturnCar(int userId, int carId)
        {
            var user = _context
                .Users
                .SingleOrDefault(u => u.Id == userId) ?? throw new NotFoundException("Użytkownik nie odnaleziony");

            var car = _context
                .Cars
                .SingleOrDefault(c => c.Id == carId) ?? throw new NotFoundException("Auto nie znalezione");

                car.Available = true;

            var rentedInfo = _context
                .RentInfo
                .SingleOrDefault(x => x.UserId == user.Id && x.CarId == car.Id && x.IsGivenBack == false) ?? throw new BadRequestException("Opps coś poszo nie tak");
            if (rentedInfo != null)
            {
                rentedInfo.IsGivenBack = true;
            }
            await Task.CompletedTask;
        }
    }
}
