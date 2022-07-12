using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Common;
using DapperORM.Application.Validations.Update;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.UpdateEvent
{
    public class UpdateProductCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public string Color { get; set; }
        public int UnitsInStock { get; set; }

    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,IResult>
    {
        private readonly IProductRepository productRepository;
        private readonly UpdateProductValidator validator;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, UpdateProductValidator validator)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public Task<IResult> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            var result = validator.Validate(product);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            productRepository.Update(product);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Updated));
        }
    }
}
