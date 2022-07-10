using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;

namespace DapperORM.Persistence.Repositories
{
    public class DapperCategoryRepository: DapperGenericRepository<Category>,ICategoryRepository
    {
        public DapperCategoryRepository(IDapperContext dapperContext):base(dapperContext,"Categories")
        {

        }
    }
}
