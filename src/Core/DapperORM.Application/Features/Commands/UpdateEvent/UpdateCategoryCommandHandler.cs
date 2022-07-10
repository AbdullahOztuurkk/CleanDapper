using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Common;
using DapperORM.Application.Validations.Update;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
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
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            EntityValidator.Validate(validator, category);
            categoryRepository.Update(category);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Updated));
        }
    }
}
