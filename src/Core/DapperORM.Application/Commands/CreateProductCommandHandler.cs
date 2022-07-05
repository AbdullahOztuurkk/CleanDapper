using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Commands
{
    public class CreateProductCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public string Color { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResult>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly CreateProductValidator validator;
        public CreateProductCommandHandler(
            IProductRepository productRepository,
            CreateProductValidator validator,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken) 
        {
            //business logic
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Added));
        }
    }
}
