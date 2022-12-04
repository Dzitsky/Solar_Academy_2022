using Microsoft.Extensions.Caching.Memory;
using ShoppingCart.AppServices.Country.Repositories;
using ShoppingCart.Contracts;

namespace ShoppingCart.AppServices.Country.Services
{
    /// <summary>
    /// Реализация <see cref="ICountryService"/>.
    /// </summary>
    public class CountryService : ICountryService
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="CountryService"/>.
        /// </summary>
        /// <param name="countryRepository">Репозиторий.</param>
        /// <param name="memoryCache">Сервис кеширования в памяти.</param>
        public CountryService(ICountryRepository countryRepository, IMemoryCache memoryCache)
        {
            _countryRepository = countryRepository;
            _memoryCache = memoryCache;
        }

        private readonly ICountryRepository _countryRepository;

        private readonly IMemoryCache _memoryCache;
        private const string AllCountriesKey = "AllCountriesKey";

        /// <inheritdoc />
        public async Task<CountryDto[]> GetAllAsync(CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(AllCountriesKey, out CountryDto[] items))
            {
                return items;
            }
            
            items = await _countryRepository.GetAllAsync(cancellationToken);

            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _memoryCache.Set(AllCountriesKey, items, options);

            return items;
        }
    }
}