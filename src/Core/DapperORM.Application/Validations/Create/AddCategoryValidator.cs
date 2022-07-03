using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Create
{
    public class AddCategoryValidator:AbstractValidator<Category>
    {
        public AddCategoryValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250)
                .WithMessage(ValidationMessages.Category_Description_Length_Error);
        }
    }
}
