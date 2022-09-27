using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Product.Services;

/// <summary>
/// Сервис для работы с товарами
/// </summary>
public interface IProductService
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