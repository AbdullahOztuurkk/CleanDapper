using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Queries
{
    public class GetCategoryQuery : IRequest<IDataResult<Category>>
    {
        public int Id { get; set; }
    }

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IDataResult<Category>>
    {
        ICategoryRepository categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<IDataResult<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = categoryRepository.Get(request.Id);
            return Task.FromResult<IDataResult<Category>>(new SuccessDataResult<Category>(result));
        }
    }
}
