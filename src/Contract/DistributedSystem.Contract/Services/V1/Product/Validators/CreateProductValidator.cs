using DistributedSystem.Contract.Services.V1.Product;
using FluentValidation;

namespace DistributedSystem.Contract.Services.V1.Identity.Validators;

public class CreateProductValidator : AbstractValidator<Command.CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

    }
}
