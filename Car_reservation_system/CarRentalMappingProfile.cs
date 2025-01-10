using AutoMapper;
using Car_reservation_system.Entities;
using Car_reservation_system.Models;

namespace Car_reservation_system
{
    public class CarRentalMappingProfile : Profile
    {
        public CarRentalMappingProfile()
        {
            CreateMap<Car, CarModelDto>();
            CreateMap<CarModelDto, Car>();
            CreateMap<User, UserModelDto>()
                .ForMember(d => d.Role, u => u.MapFrom(r => r.Role.Name));
        }
    }
}
