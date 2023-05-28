namespace FactoryDesingPatternSample
{
    public class ProductA : IProduct
    {
        public string GetDescription()
        {
            return "Desc Product A";
        }

        public string GetName()
        {
            return "Prodcut A";
        }
    }
}