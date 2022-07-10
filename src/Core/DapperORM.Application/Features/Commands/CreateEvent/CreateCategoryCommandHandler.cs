using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Common;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.CreateEvent
{
    public class CreateCategoryCommandRequest: IRequest<IResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, IResult>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly CreateCategoryValidator validator;
        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            CreateCategoryValidator validator,
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            EntityValidator.Validate(validator, category);
            categoryRepository.Add(category);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Added));
        }
    }
}
