using Command.Domain.Abstractions.Repositories;
using Command.Domain.Exceptions;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using CommandV1 = DistributedSystem.Contract.Services.V1.Product.Command;

namespace Command.Application.UserCases.V1.Commands.Product;

public sealed class UpdateProductCommandHandler : ICommandHandler<CommandV1.UpdateProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;

    public UpdateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(CommandV1.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id) ?? throw new ProductException.ProductNotFoundException(request.Id); // Solution 1
        product.Update(request.Name, request.Price, request.Description);

        return Result.Success();
    }
}
