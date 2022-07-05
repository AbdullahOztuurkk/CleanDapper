using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;
using System.Drawing;

namespace DapperORM.Application.Validations.Create
{
    public class CreateProductValidator : AbstractValidator<Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(70)
                .WithMessage(ValidationMessages.Product_Name_Length_Error);

            RuleFor(p => p.Color)
                .NotEmpty()
                .IsEnumName(typeof(KnownColor))
                .WithMessage(ValidationMessages.Product_Color_Must_be_Known_Color);

            RuleFor(p => p.QuantityPerUnit)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(ValidationMessages.Product_Quantity_Must_Greater_Than_Zero);

            RuleFor(p => p.UnitPrice)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage(ValidationMessages.Product_Price_Must_Greater_Than_Or_Equal_To_Zero);

            RuleFor(p => p.UnitsInStock)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(ValidationMessages.Product_Stock_Must_Greater_Than_Zero);
        }
    }
}
