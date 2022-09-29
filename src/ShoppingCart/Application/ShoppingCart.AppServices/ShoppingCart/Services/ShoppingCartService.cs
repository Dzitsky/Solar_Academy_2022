using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <inheritdoc />
public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    /// <inheritdoc />
    public Task<IReadOnlyCollection<ShoppingCartDto>> GetAsync(CancellationToken cancellation)
    {
        return _shoppingCartRepository.GetAllAsync(cancellation);
    }

    /// <inheritdoc />
    public Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
    {
        return _shoppingCartRepository.UpdateQuantityAsync(id, quantity, cancellation);
    }

    /// <inheritdoc />
    public Task DeleteAsync(Guid id, CancellationToken cancellation)
    {
        return _shoppingCartRepository.DeleteAsync(id, cancellation);
    }
}