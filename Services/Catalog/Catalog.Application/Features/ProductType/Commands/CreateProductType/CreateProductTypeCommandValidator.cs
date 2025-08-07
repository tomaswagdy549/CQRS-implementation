using FluentValidation;

namespace Catalog.Application.Features.ProductType.Commands.CreateProductType
{
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        public CreateProductTypeCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(50).WithMessage("Product name length should be less than 50");
        }
    }
}
