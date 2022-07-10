using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Update
{
    public class UpdateCategoryValidator : AbstractValidator<Category>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
            RuleFor(p => p.Description).CheckCategoryDescription();
            RuleFor(p => p.Name).CheckCategoryName();
        }
    }
}
