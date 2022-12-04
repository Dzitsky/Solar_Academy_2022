using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api.Tests.AssertHelpers;
using ShoppingCart.Contracts;
using ShoppingCart.DataAccess;
using ShoppingCart.Domain;
using Shouldly;
using Xunit;

namespace ShoppingCart.Api.Tests
{
    public class CountryApiTests : IClassFixture<ShoppingCartApplicationFactory<Program>>
    {
        public CountryApiTests(ShoppingCartApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        private readonly ShoppingCartApplicationFactory<Program> _factory;

        [Fact]
        public async Task GetAll_Success()
        {
            // arrange
            var httpClient = _factory.CreateClient();

            // act
            var response = await httpClient.GetAsync("/v1/Country");
            var result = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<CountryDto>>();

            // assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(10);

            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ShoppingCartContext>();
                var allFromDb = await db.Set<Country>().ToArrayAsync();

                result.ShouldBeEquivalentTo(allFromDb);
            }
        }
    }
}