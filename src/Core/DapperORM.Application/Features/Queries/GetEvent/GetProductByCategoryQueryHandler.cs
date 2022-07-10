using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.GetEvent
{
    public class GetProductByCategoryQueryRequest : IRequest<IDataResult<List<Product>>>
    {
        public int Id { get; set; }
    }
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, IDataResult<List<Product>>>
    {
        private readonly IProductRepository productRepository;
        public GetProductByCategoryQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<IDataResult<List<Product>>> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = productRepository.GetProductByCategoryId(request.Id);
            return Task.FromResult<IDataResult<List<Product>>>(new SuccessDataResult<List<Product>>(result));
        }
    }
}
