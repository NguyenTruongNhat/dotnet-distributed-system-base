using Command.Domain.Abstractions.Repositories;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using CommandV1 = DistributedSystem.Contract.Services.V1.Product.Command;

namespace Command.Application.UserCases.V1.Commands.Product;

public sealed class CreateProductCommandHandler : ICommandHandler<CommandV1.CreateProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;

    public CreateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(CommandV1.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);
        _productRepository.Add(product);

        return Result.Success();
    }
}
