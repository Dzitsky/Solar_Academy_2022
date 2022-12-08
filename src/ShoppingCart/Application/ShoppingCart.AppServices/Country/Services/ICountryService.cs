using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Country.Services
{
    /// <summary>
    /// Сервис для стран.
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Получить все страны.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<CountryDto[]> GetAllAsync(CancellationToken cancellationToken);
    }
}