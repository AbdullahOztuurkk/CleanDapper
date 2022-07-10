using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Delete
{
    public class DeleteProductValidator : AbstractValidator<Product>
    {
        public DeleteProductValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
        }
    }
}
