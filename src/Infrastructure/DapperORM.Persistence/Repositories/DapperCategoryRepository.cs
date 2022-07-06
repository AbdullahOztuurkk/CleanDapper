using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;
using DapperORM.Persistence.Context;

namespace DapperORM.Persistence.Repositories
{
    public class DapperCategoryRepository: DapperGenericRepository<Category>,ICategoryRepository
    {
        public DapperCategoryRepository(DapperContext dapperContext):base(dapperContext)
        {

        }
    }
}
