using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ShoppingCart.Contracts.Product;
using Shouldly;
using Xunit;

namespace ShoppingCart.Api.Tests
{
    public class ProductApiTests : IClassFixture<ShoppingCartApplicationFactory<Program>>
    {
        public ProductApiTests(ShoppingCartApplicationFactory<Program> factory)
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
            var response = await httpClient.GetAsync("/v1/Product?take=10000");
            var result = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<ProductDto>>();

            // assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(10);
        }
    }
}