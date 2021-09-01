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
        private const int MaxPageSize = 50;
        private const int MinPageSize = 10;
        private const int MinPageNumber = 1;

        public UseCasesTests()
        {
            _productsRepositoryMoq = new Mock<IProductsRepository>();
            _faker = new Faker();
            _fixture = new Fixture();
        }

        private int GetValidPageSize()
        {
            return _faker.Random.Number(MinPageSize, MaxPageSize);
        }

        private int GetPageSizeOverMaxLimit()
        {
            return _faker.Random.Number(MaxPageSize+1, 100);
        }

        private int GetPageSizeBelowMinLimit()
        {
            return _faker.Random.Number(-100, MinPageSize-1);
        }

        private int GetValidPageNumber()
        {
            return _faker.Random.Number(MinPageNumber, 100);
        }

        private List<Product> CreateRandomRepositoryProducts(int pageSize)
        {
            return _fixture.CreateMany<Product>(pageSize).ToList();
        }

        private int GetPageNumberBelowMinLimit()
        {
            return _faker.Random.Number(-100, MinPageNumber-1);
        }
    }
}