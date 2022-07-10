using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.DeleteEvent
{
    public class DeleteCategoryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, IResult>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public Task<IResult> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = mapper.Map<Category>(request);
            categoryRepository.Delete(category);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Deleted));
        }
    }
}
