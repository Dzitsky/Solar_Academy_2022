using Microsoft.EntityFrameworkCore;
using ShoppingCart.AppServices.Product.Repositories;
using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Contracts;
using ShoppingCart.Contracts.Product;
using ShoppingCart.Infrastructure.Repository;

namespace ShoppingCart.DataAccess.EntityConfigurations.Product;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
    private readonly IRepository<Domain.User> _repository;

    /// <summary>
    /// Инициализирует экземпляр <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="repository">Базовый репозиторий.</param>
    public UserRepository(IRepository<Domain.User> repository)
    {
        _repository = repository;
    }

    ///// <inheritdoc />
    //public async Task<IReadOnlyCollection<ProductDto>> GetAll(int take, int skip, CancellationToken cancellation)
    //{
    //    return await _repository.GetAll()
    //        .Select(p => new UserDto
    //        {
    //            Id = p.Id,
    //            Name = p.Name,
    //            Description = p.Description,
    //            Price = p.Price
    //        })
    //        .Take(take).Skip(skip).ToListAsync(cancellation);
    //}
}