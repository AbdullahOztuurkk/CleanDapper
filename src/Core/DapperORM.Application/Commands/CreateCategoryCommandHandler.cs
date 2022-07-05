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
    public class CreateCategoryCommand: IRequest<IResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
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
        public Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //business logic
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Category_Added));
        }
    }
}
