using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Commands
{
    public class DeleteProductCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResult>
    {
        IProductRepository productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //business logic
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Deleted));
        }
    }
}
