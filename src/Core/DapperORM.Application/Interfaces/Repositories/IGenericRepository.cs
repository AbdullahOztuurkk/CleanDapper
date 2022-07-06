using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
