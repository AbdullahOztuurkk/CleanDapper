using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Delete
{
    public class DeleteCategoryValidator : AbstractValidator<Category>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
        }
    }
}