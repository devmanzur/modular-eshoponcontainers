using Catalog.Core.Rules;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class Stock : ValueData
    {
        public Stock(int value)
        {
            CheckRule(new StockMustNotBeNegativeRule(value));
            Value = value;
        }

        public int Value { get; private set; }
    }
}