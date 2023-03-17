using System.Collections.Generic;
using System.Linq;
using TarrifComparison.Common;
using TarrifComparison.Products;
using TarrifComparison.Products.Impls;

namespace TarrifComparison.Services
{
    public class ProductService
    {
        public List<BaseProductTariff> GetProducts(int consumption)
        {
            var products = new List<BaseProductTariff>();
            var packageProduct = new PackagedTariff(consumption,
                Consts.BaseAnnualCost,Consts.BaseConsumption,Consts.BaseAllowedDifference,
                Consts.AddedKwPrice);
            var basicProduct = new BasicTarrif(consumption,Consts.KwPrice,
                Consts.BaseMonthlyPrice);
            packageProduct.Calculate();
            basicProduct.Calculate();
            products.Add(packageProduct);
            products.Add(basicProduct);
            return products.OrderByDescending(x => x.AnnualCost).ToList();
        }
    }
}
