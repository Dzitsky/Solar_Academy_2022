using Microsoft.EntityFrameworkCore;
using ShoppingCart.AppServices.Product.Repositories;
using ShoppingCart.Contracts;
using ShoppingCart.Infrastructure.Repository;

namespace ShoppingCart.DataAccess.EntityConfigurations.Product;

public class ProductRepository : IProductRepository
{
    private readonly IRepository<Domain.Product> _repository;

    public ProductRepository(IRepository<Domain.Product> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetAll(int take, int skip)
    {
        return await _repository.GetAll()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .Take(take).Skip(skip).ToListAsync();
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetAllFiltered(ProductFilterRequest request)
    {
        var query = _repository.GetAll();

        if (request.Id.HasValue)
        {
            query = query.Where(p => p.Id == request.Id);
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(p => p.Name.ToLower().Contains(request.Name.ToLower()));
        }
            
        return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToListAsync();
    }
}