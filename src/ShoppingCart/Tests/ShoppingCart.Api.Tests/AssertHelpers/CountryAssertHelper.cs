using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Contracts;
using ShoppingCart.Domain;
using Shouldly;

namespace ShoppingCart.Api.Tests.AssertHelpers
{
    public static class CountryAssertHelper
    {
        public static void ShouldBeEquivalentTo(this IEnumerable<CountryDto> dtos, IEnumerable<Country> entities)
        {
            var orderedDtos = dtos.OrderBy(x => x.Name).ToArray();
            var orderedEntities = entities.OrderBy(x => x.Name).ToArray();

            orderedDtos.Length.ShouldBe(orderedEntities.Length);

            for (var i = 0; i < orderedDtos.Length; i++)
            {
                var dto = orderedDtos[i];
                var entity = orderedEntities[i];

                dto.ShouldBeEquivalentTo(entity);
            }
        }

        public static void ShouldBeEquivalentTo(this CountryDto dto, Country entity)
        {
            dto.Id.ShouldBe(entity.Id);
            dto.Name.ShouldBe(entity.Name);
            dto.Code.ShouldBe(entity.Code);
        }
    }
}