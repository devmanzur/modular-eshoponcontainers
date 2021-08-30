using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class Stock : ValueData
    {
        public Stock(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }
}