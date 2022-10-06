using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

//    /// <inheritdoc />
//    public Task<IReadOnlyCollection<ShoppingCartDto>> GetAsync(CancellationToken cancellation)
//    {
//        return _shoppingCartRepository.GetAllAsync(cancellation);
//    }

//    /// <inheritdoc />
//    public Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
//    {
//        return _shoppingCartRepository.UpdateQuantityAsync(id, quantity, cancellation);
//    }

//    /// <inheritdoc />
//    public Task DeleteAsync(Guid id, CancellationToken cancellation)
//    {
//        return _shoppingCartRepository.DeleteAsync(id, cancellation);
   //}
}