using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Commands
{
    public class DeleteCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        ICategoryRepository categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //business logic
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Deleted));
        }
    }
}
