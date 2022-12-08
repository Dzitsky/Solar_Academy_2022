using System;
using Bogus;
using ShoppingCart.DataAccess;
using ShoppingCart.Domain;

namespace ShoppingCart.Api.Tests
{
    public static class DataSeedHelper
    {
        public static void InitializeDbForTests(ShoppingCartContext context)
        {
            // добавить товары
            var productFaker = new Faker<Product>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Commerce.Random.Decimal(10, 1000));

            var products = productFaker.Generate(10);

            context.Set<Product>().AddRange(products);

            // добавить страны
            var countryFaker = new Faker<Country>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, f => f.Address.Country())
                .RuleFor(x => x.Code, f => f.Address.ZipCode());

            var countries = countryFaker.Generate(10);
            
            context.Set<Country>().AddRange(countries);

            context.SaveChanges();
        }
    }
}