using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace Catalog.Core.Tests.Core.Rules
{
    public partial class BusinessRulesTests
    {
        private readonly Faker _faker;

        private List<string> _validExtensions = new()
        {
            "jpg",
            "jpeg",
            "png",
        };

        public BusinessRulesTests()
        {
            _faker = new Faker();
        }

        private string GetValidImageUrl()
        {
            var fileName = _faker.Random.String();
            var index = _faker.Random.Number(min: 0, max: _validExtensions.Count - 1);
            var extension = _validExtensions[index];
            return $"{fileName}.{extension}";
        }
    }
}