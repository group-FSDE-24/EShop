using FluentValidation;
using EShop.Application.DTOS.Product;

namespace EShop.Application.Validations.Product;

public class AddProductValidator : AbstractValidator<AddProductDto>
{
    public AddProductValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Ad daxil edilmelidir");


    }
}
