using Command.Domain.Abstractions.Repositories;
using Command.Domain.Exceptions;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using CommandV1 = DistributedSystem.Contract.Services.V1.Product.Command;

namespace Command.Application.UserCases.V1.Commands.Product;

public sealed class DeleteProductCommandHandler : ICommandHandler<CommandV1.DeleteProductCommand>
{
    private readonly IRepositoryBase<Command.Domain.Entities.Product, Guid> _productRepository;

    public DeleteProductCommandHandler(IRepositoryBase<Command.Domain.Entities.Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(CommandV1.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id) ?? throw new ProductException.ProductNotFoundException(request.Id);
        //product.Delete();
        _productRepository.Remove(product);

        return Result.Success();
    }
}
