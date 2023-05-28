namespace FactoryDesingPatternSample
{
    public class ProductB : IProduct
    {
        public string GetDescription()
        {
            return "Desc Product B";
        }

        public string GetName()
        {
            return "Product B";
        }
    }
}