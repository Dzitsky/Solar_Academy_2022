using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.AppServices.Country.Services;
using ShoppingCart.Contracts;

namespace ShoppingCart.Api.Controllers
{
    /// <summary>
    /// Контроллер для стран.
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class CountryController : ControllerBase
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="CountryController"/>
        /// </summary>
        /// <param name="countryService"></param>
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        private readonly ICountryService _countryService;

        /// <summary>
        /// Получить список всех стран.
        /// </summary>
        /// <param name="cancellation">Токен отмены.</param>
        /// <returns>Список стран.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<CountryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var result = await _countryService.GetAllAsync(cancellation);

            return Ok(result);
        }
    }
}