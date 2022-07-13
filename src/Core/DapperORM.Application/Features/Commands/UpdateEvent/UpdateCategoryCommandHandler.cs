using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
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
    public class UpdateCategoryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, IResult>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly UpdateCategoryValidator validator;
        private readonly IMapper mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, UpdateCategoryValidator validator)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public Task<IResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            var result = validator.Validate(category);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            categoryRepository.Update(category);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Updated));
        }
    }
}
