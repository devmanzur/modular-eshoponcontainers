using CrossCuttingConcerns.Core.Rules;

namespace Catalog.Core.Rules
{
    public class StockMustNotBeNegativeRule : IBusinessRule
    {
        private readonly int _stock;

        public StockMustNotBeNegativeRule(int stock)
        {
            _stock = stock;
        }
        public bool IsBroken()
        {
            return _stock < 0;
        }

        public string Message => "Stock cannot be negative";
    }
}