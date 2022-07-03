using DapperORM.Application.Interfaces.Repositories;

namespace DapperORM.Application.Interfaces.UnitOfWork
{
    public class IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
    }
}
