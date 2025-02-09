﻿using System.Linq.Expressions;

namespace Car_reservation_system.Repositories.IRepositories
{
    public interface IRepository<T, Dto> where T : class 
                                         where Dto : class
    {
        Task<Dto> GetFirstOrDefaultDtoAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<Dto>> GetAllDtoAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
