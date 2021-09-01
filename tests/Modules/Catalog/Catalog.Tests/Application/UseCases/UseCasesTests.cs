using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Bogus;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using Moq;

namespace Catalog.Core.Tests.Application.UseCases
{
    public partial class UseCasesTests
    {
        private readonly Faker _faker;
        private readonly Mock<IProductsRepository> _productsRepositoryMoq;
        private readonly Fixture _fixture;

        public UseCasesTests()
        {
            _productsRepositoryMoq = new Mock<IProductsRepository>();
            _faker = new Faker();
            _fixture = new Fixture();
        }

        private int GetValidPageSize()
        {
            return _faker.Random.Number(1, 30);
        }
        private int GetPageSizeOverMaxLimit()
        {
            return _faker.Random.Number(31, 100);
        }
        private int GetPageSizeBelowMinLimit()
        {
            return _faker.Random.Number(-100, 8);
        }

        private int GetValidPageNumber()
        {
            return _faker.Random.Number(1,100);
        }

        private List<Product> CreateRandomRepositoryProducts(int pageSize)
        {
            return _fixture.CreateMany<Product>(pageSize).ToList();
        }
    }
}