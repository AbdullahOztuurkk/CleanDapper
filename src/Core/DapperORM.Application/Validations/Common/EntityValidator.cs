using DapperORM.Domain.Common.Result;
using FluentValidation;
using System.Threading.Tasks;

namespace DapperORM.Application.Validations.Common
{
    public static class EntityValidator
    {
        public static Task<IResult> Validate<T>(IValidator<T> validator, T value)
        {
            var result = validator.Validate(value);
            if (result.Errors.Count > 0)
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.ToString()));
            return null;
        }
    }
}
