using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Common
{
    public static class CategoriesRules
    {
        public static IRuleBuilderOptions<T, string> CheckCategoryDescription<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Category
        {
            return ruleBuilder
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250)
                .WithMessage(ValidationMessages.Category_Description_Length_Error);
        }

        public static IRuleBuilderOptions<T, string> CheckCategoryName<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Category
        {
            return ruleBuilder
                .NotEmpty()
                .MinimumLength(0)
                .MaximumLength(30)
                .WithMessage(ValidationMessages.Category_Name_Length_Error);
        }

    }
}
