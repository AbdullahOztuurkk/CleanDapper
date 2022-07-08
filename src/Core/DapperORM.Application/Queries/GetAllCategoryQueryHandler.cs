using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Queries
{
    public class GetAllCategoryQueryRequest : IRequest<IDataResult<List<Category>>> { }
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IDataResult<List<Category>>>
    {
        ICategoryRepository categoryRepository;
        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<IDataResult<List<Category>>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = categoryRepository.GetAll();
            return Task.FromResult<IDataResult<List<Category>>>(new SuccessDataResult<List<Category>>(result));
        }
    }
    
}
