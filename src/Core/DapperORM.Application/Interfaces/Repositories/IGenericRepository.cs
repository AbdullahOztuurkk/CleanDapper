using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T model);
        Task<T> RemoveAsync(Guid Id);
    }
}
