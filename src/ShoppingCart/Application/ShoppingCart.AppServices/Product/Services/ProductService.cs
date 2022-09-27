using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Product.Services;

public class ProductService : IProductService
{
    
    
    
    public Task<IReadOnlyCollection<ProductDto>> GetAll(int take, int skip)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ProductDto>> GetAllFiltered(ProductFilterRequest request)
    {
        throw new NotImplementedException();
    }
}