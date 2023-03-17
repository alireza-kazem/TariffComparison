namespace TarrifComparison.Products
{
    public abstract class BaseProductTariff
    {
        public string Name { get; protected set; }
        public decimal AnnualCost { get; protected set; }
    }
}
