using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Delete;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Linq;
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
        private readonly DeleteCategoryValidator validator;
        private readonly IMapper mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, DeleteCategoryValidator validator)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public Task<IResult> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = mapper.Map<Category>(request);
            var result = validator.Validate(category);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            categoryRepository.Delete(category);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Deleted));
        }
    }
}
