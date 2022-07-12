using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Common
{
    public static class CategoriesRules
    {
        public static IRuleBuilderOptions<T, string> CheckCategoryDescription<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Category
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Category_Description_Length_Error)
                .MinimumLength(3).WithMessage(ValidationMessages.Category_Description_Length_Error)
                .MaximumLength(250).WithMessage(ValidationMessages.Category_Description_Length_Error);
        }

        public static IRuleBuilderOptions<T, string> CheckCategoryName<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Category
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Category_Name_Length_Error)
                .MinimumLength(0).WithMessage(ValidationMessages.Category_Name_Length_Error)
                .MaximumLength(30).WithMessage(ValidationMessages.Category_Name_Length_Error);
        }

    }
}
