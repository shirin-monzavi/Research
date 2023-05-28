using FactoryDesingPatternSample;

internal class Program
{
    public static void Main(string[] args)
    {
        ProductFactory factory = new ProductFactoryA();

        IProduct product = factory.CreateProduct();

        Console.WriteLine("product a " + product.GetName() + ":" + product.GetDescription());

        Console.WriteLine("<----------------->");

        ProductFactory factoryB = new ProductFactoryB();

        product = factoryB.CreateProduct();

        Console.WriteLine("product B " + product.GetName() + ":" + product.GetDescription());
    }
}