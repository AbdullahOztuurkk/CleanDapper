using DapperORM.Domain.Entities;
using System.Collections.Generic;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public List<Product> GetProductByCategoryId(int Id);
    }
}
