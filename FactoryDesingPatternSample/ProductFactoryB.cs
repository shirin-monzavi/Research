namespace FactoryDesingPatternSample
{
    public class ProductFactoryB : ProductFactory
    {
        public override IProduct CreateProduct()
        {
            return new ProductB();
        }
    }
}