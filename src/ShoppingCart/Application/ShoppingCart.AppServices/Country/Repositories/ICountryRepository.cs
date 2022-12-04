using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Country.Repositories
{
    /// <summary>
    /// Репозиторий для стран.
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Получить все страны.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<CountryDto[]> GetAllAsync(CancellationToken cancellationToken);
    }
}