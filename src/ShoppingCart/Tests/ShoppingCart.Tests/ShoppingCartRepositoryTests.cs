using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using ShoppingCart.DataAccess.EntityConfigurations.ShoppingCart;
using ShoppingCart.Domain;
using ShoppingCart.Infrastructure.Repository;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ShoppingCartRepositoryTests
    {
        [Fact]
        public async Task GetAll_ShoppingCart_Success()
        {
            // arrange
            var entities = new List<Domain.ShoppingCart>(new[]
            {
                new Domain.ShoppingCart { Id = Guid.NewGuid(), Amount = 1, Quantity = 1, Product = new Product { Name = "milk" }, Price = 50 },
                new Domain.ShoppingCart { Id = Guid.NewGuid(), Amount = 2, Quantity = 2, Product = new Product { Name = "bread" }, Price = 30 }
            });

            var entitiesMock = entities.BuildMock();

            var repositoryMock = new Mock<IRepository<Domain.ShoppingCart>>();
            
            repositoryMock.Setup(x => x.GetAll()).Returns(entitiesMock);

            CancellationToken token = new CancellationToken(false);

            // act
            ShoppingCartRepository repository = new ShoppingCartRepository(repositoryMock.Object);
            var result = await repository.GetAllAsync(token);

            // assert
            repositoryMock.Verify(x => x.GetAll(), Times.Once);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            
            var resultArray = result.ToArray();
            var expectArray = entities.ToArray();

            for (var i = 0; i < resultArray.Length; i++)
            {
                var actual = resultArray[i];
                var expect = expectArray[i];

                actual.Id.ShouldBe(expect.Id);
                actual.ProductName.ShouldBe(expect.Product.Name);
                actual.Quantity.ShouldBe(expect.Quantity);
                actual.Amount.ShouldBe(expect.Amount);
                actual.Price.ShouldBe(expect.Price);
            }
        }

        [Fact]
        public async Task Create_ShoppingCart_Success()
        {
            var newId = Guid.NewGuid();

            Domain.ShoppingCart createdDomain = null!;

            var repositoryMock = new Mock<IRepository<Domain.ShoppingCart>>();
            
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<Domain.ShoppingCart>()))
                .Callback((Domain.ShoppingCart x) =>
                {
                    x.Id = newId;
                    createdDomain = x;
                });

            CancellationToken token = new CancellationToken(false);

            // act
            ShoppingCartRepository repository = new ShoppingCartRepository(repositoryMock.Object);
            var result = await repository.CreateAsync(token);

            // assert
            createdDomain.ShouldNotBeNull();
            repositoryMock.Verify(x => x.AddAsync(createdDomain), Times.Once);

            result.ShouldNotBe(Guid.Empty);
            result.ShouldBe(newId);
        }
    }
}