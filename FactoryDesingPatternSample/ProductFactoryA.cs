namespace FactoryDesingPatternSample
{
    public class ProductFactoryA : ProductFactory
    {
        public override IProduct CreateProduct()
        {
            return new ProductA();
        }
    }
}