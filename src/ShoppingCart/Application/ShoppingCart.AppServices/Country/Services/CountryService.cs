using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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
        /// <param name="distributedCache">Распределённый кеш.</param>
        public CountryService(ICountryRepository countryRepository, IDistributedCache distributedCache)
        {
            _countryRepository = countryRepository;
            _distributedCache = distributedCache;
        }

        private readonly ICountryRepository _countryRepository;
        
        private const string AllCountriesKey = "AllCountriesKey";
        private readonly IDistributedCache _distributedCache;

        /// <inheritdoc />
        public async Task<CountryDto[]> GetAllAsync(CancellationToken cancellationToken)
        {
            CountryDto[] items;

            var str = await _distributedCache.GetStringAsync(AllCountriesKey, cancellationToken);
            if (!string.IsNullOrWhiteSpace(str))
            {
                items = JsonConvert.DeserializeObject<CountryDto[]>(str);
                return items;
            }

            items = await _countryRepository.GetAllAsync(cancellationToken);

            var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
            await _distributedCache.SetStringAsync(AllCountriesKey, JsonConvert.SerializeObject(items), options,
                cancellationToken);

            return items;
        }
    }
}