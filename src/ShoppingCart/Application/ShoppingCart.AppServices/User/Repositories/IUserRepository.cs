using System.Linq.Expressions;
using ShoppingCart.Domain;

namespace ShoppingCart.AppServices.ShoppingCart.Repositories;

/// <summary>
/// Репозиторий для чтения записи элементов корзины товаров.
/// </summary>
public interface IUserRepository
{
    Task<User> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);

    Task<User> FindById(Guid Id, CancellationToken cancellationToken);

    Task AddAsync(User model);

    
    ///// <summary>
    ///// Возвращает все элементы корзины.
    ///// </summary>
    ///// <returns>Коллекция элементов корзины <see cref="ShoppingCartDto"/>.</returns>
    //Task<IReadOnlyCollection<ShoppingCartDto>> GetAllAsync(CancellationToken cancellation);

    ///// <summary>
    ///// Обновляет количество товара в корзине.
    ///// </summary>
    ///// <param name="id">Идентификатор позиции корзины.</param>
    ///// <param name="quantity">Новое количество товара.</param>
    //Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation);

    ///// <summary>
    ///// Удаляет товар из корзины.
    ///// </summary>
    ///// <param name="id">Идентификатор позиции корзины.</param>
    //Task DeleteAsync(Guid id, CancellationToken cancellation);
}