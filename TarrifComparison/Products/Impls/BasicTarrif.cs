using TariffComparison.Products;
using TarrifComparison.Common.Guards;

namespace TarrifComparison.Products.Impls
{
    public class BasicTarrif : BaseProductTariff, IProduct
    {
        private decimal _kwPrice;
        private decimal _baseMonthlyPrice;
        private int _consumption;

        public BasicTarrif(int consumption, decimal kwPrice, decimal baseMonthlyPrice)
        {
            _kwPrice = kwPrice.GuardAgainstZeroOrNegative();
            _baseMonthlyPrice = baseMonthlyPrice.GuardAgainstZeroOrNegative();
            _consumption = consumption.GuardAgainstZeroOrNegative();
            Name = "Basic electricity tariff";
        }

        public void Calculate()
        {
            var baseCost = _baseMonthlyPrice * 12;
            var cost = _consumption * _kwPrice;
            AnnualCost = baseCost + cost;
        }
    }
}
