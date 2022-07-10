using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Update
{
    public class UpdateProductValidator : AbstractValidator<Product>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id).CheckIdentifierNumber();
            RuleFor(p => p.Color).CheckProductColor();
            RuleFor(p => p.Name).CheckProductName();
            RuleFor(p => p.UnitPrice).CheckProductPrice();
            RuleFor(p => p.UnitsInStock).CheckProductStock();
            RuleFor(p => p.QuantityPerUnit).CheckProductQuantity();
        }
    }
}
