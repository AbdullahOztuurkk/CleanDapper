﻿using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Queries
{
    public class GetAllProductQuery : IRequest<IDataResult<List<Product>>> { }
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IDataResult<List<Product>>>
    {
        IProductRepository productRepository;
        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<IDataResult<List<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = productRepository.GetAll();
            return Task.FromResult<IDataResult<List<Product>>>(new SuccessDataResult<List<Product>>(result));
        }
    }
}
