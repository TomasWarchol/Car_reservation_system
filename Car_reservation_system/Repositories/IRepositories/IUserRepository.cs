﻿using Car_reservation_system.Controllers;
using Car_reservation_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_reservation_system.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<User, UserModelDto>
    {
        Task RegisterAsync(RegisterModelDto dto);
        Task LoginAsync(LoginModelDto dto);
        Task LogoutAsync();
        Task UpdateAsync(UserModelDto userDto);

        Task<bool> UserNameOrPasswordInvalid(LoginModelDto dto);
        Task<IEnumerable<UserModelDto>> GetAllUsersDto();
        Task<UserModelDto> GetUserDetails(int userId);
    }
}
