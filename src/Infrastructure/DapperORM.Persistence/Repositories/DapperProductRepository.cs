using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;
using DapperORM.Persistence.Context;

namespace DapperORM.Persistence.Repositories
{
    public class DapperProductRepository : DapperGenericRepository<Product>,IProductRepository
    {
        public DapperProductRepository(DapperContext dapperContext):base(dapperContext)
        {

        }
    }
}
