using Catalog.Core.Enums;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class Price : ValueData
    {
        public Price(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }
    }
}