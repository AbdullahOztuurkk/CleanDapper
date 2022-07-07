using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Queries
{
    public class GetProductQuery : IRequest<IDataResult<Product>>
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IDataResult<Product>>
    {
        IProductRepository productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<IDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = productRepository.Get(request.Id);
            return Task.FromResult<IDataResult<Product>>(new SuccessDataResult<Product>(result));
        }
    }
}
