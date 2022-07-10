using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Common;
using DapperORM.Application.Validations.Delete;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.DeleteEvent
{
    public class DeleteProductCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, IResult>
    {
        private readonly IProductRepository productRepository;
        private readonly DeleteProductValidator validator;
        private readonly IMapper mapper;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, DeleteProductValidator validator)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public Task<IResult> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = mapper.Map<Product>(request);
            EntityValidator.Validate(validator, product);
            productRepository.Delete(product);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Deleted));
        }
    }
}
