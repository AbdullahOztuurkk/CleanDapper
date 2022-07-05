using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Create
{
    public class CreateCategoryValidator:AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250)
                .WithMessage(ValidationMessages.Category_Description_Length_Error);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(0)
                .MaximumLength(30)
                .WithMessage(ValidationMessages.Category_Name_Length_Error);
        }
    }
}
