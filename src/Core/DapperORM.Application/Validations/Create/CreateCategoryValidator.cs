using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Create
{
    public class CreateCategoryValidator:AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(p => p.Description).CheckCategoryDescription();
            RuleFor(p => p.Name).CheckCategoryName();
        }
    }
}
