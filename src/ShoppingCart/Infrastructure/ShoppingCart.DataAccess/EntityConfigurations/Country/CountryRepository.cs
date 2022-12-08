using Microsoft.EntityFrameworkCore;
using ShoppingCart.AppServices.Country.Repositories;
using ShoppingCart.Contracts;
using ShoppingCart.Infrastructure.Repository;

namespace ShoppingCart.DataAccess.EntityConfigurations.Country
{
    /// <summary>
    /// Реализация <see cref="ICountryRepository"/>
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly IRepository<Domain.Country> _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="CountryRepository"/>
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public CountryRepository(IRepository<Domain.Country> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Task<CountryDto[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return _repository.GetAll().Select(x => new CountryDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToArrayAsync(cancellationToken);
        }
    }
}