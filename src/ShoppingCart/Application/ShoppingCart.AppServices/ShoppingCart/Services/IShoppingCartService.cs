using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <summary>
/// 
/// </summary>
public interface IShoppingCartService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<ShoppingCartDto>> GetAsync(CancellationToken cancellation);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(CancellationToken cancellation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellation);
}