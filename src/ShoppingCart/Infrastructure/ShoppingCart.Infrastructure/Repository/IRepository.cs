using System.Linq.Expressions;

namespace ShoppingCart.Infrastructure.Repository;

/// <summary>
/// Базовый репозиторий.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity: class
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> filter);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetByIdAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    Task AddAsync(TEntity model);
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    Task UpdateAsync(TEntity model);
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    Task DeleteAsync(TEntity model);
}