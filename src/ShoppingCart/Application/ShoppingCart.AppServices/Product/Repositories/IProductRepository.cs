using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Product.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<ProductDto>> GetAll(int take, int skip);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<ProductDto>> GetAllFiltered(ProductFilterRequest request);
}