using DapperORM.Domain.Constants;
using FluentValidation;

namespace DapperORM.Application.Validations.Common
{
    public static class SharedRules
    {
        public static IRuleBuilderOptions<T, int> CheckIdentifierNumber<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Id_Cannot_Be_Empty)
                .NotNull().WithMessage(ValidationMessages.Id_Cannot_Be_Empty);
        }
    }
}
