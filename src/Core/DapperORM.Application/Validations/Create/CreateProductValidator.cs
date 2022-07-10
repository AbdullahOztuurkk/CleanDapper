using DapperORM.Application.Validations.Common;
using DapperORM.Domain.Entities;
using FluentValidation;

namespace DapperORM.Application.Validations.Create
{
    public class CreateProductValidator : AbstractValidator<Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).CheckProductName();
            RuleFor(p => p.Color).CheckProductColor();
            RuleFor(p => p.QuantityPerUnit).CheckProductQuantity();
            RuleFor(p => p.UnitPrice).CheckProductPrice();
            RuleFor(p => p.UnitsInStock).CheckProductStock();
        }
    }
}
