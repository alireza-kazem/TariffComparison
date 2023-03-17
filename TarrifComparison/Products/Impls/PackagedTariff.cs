using TariffComparison.Products;
using TarrifComparison.Common.Guards;

namespace TarrifComparison.Products.Impls
{
    public class PackagedTariff : BaseProductTariff, IProduct
    {
        private int _baseConsumption;
        private int _baseAllowedDifference;
        private decimal _addedKwPrice;
        private int _consumption;

        public PackagedTariff(int consumption, decimal baseAnnualCost, int baseConsumbtion, int baseAllowedDifference, decimal addedKwPrice)
        {
            AnnualCost = baseAnnualCost.GuardAgainstZeroOrNegative();
            _baseConsumption = baseConsumbtion.GuardAgainstZeroOrNegative();
            _baseAllowedDifference = baseAllowedDifference.GuardAgainstZeroOrNegative();
            _addedKwPrice = addedKwPrice.GuardAgainstZeroOrNegative();
            _consumption = consumption.GuardAgainstZeroOrNegative();
            Name = "Packaged tariff";
        }
        
        public void Calculate()
        {
            if (_consumption > _baseConsumption)
            {
                var diffrence = CalculateDifference();
                AnnualCost += diffrence * _addedKwPrice;
            }
        }

        private int CalculateDifference()
        {
            var diffrence = _consumption - _baseConsumption;
            if (diffrence > _baseAllowedDifference)
            {
                diffrence = diffrence - _baseAllowedDifference;
            }
            return diffrence;
        }
    }
}
