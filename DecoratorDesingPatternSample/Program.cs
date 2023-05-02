using DecoratorDesingPatternSample;

class Program
{
    public static void Main(string[] args)
    {
        Beverage beverage = new Espresso();
        Console.WriteLine(beverage.Description + " " + beverage.Cost());

        Beverage beverage1 = new HouseBlend();
        beverage1 = new Mocha(beverage1);
        Console.WriteLine(beverage1.Description + " " + beverage1.Cost());

        Beverage beverage2 = new HouseBlend();
        beverage2 = new Mocha(beverage2);
        Console.WriteLine(beverage2.Description + " " + beverage2.Cost());
    }
}