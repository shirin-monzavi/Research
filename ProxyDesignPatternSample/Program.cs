using ProxyDesignPatternSample;

var proxy = new MathLoggingProxy();
Console.WriteLine("20 + 2 = " + proxy.Add(20, 2));
Console.WriteLine("20 - 2 = " + proxy.Subtract(20, 2));
Console.WriteLine("20 x 2 = " + proxy.Multiply(20, 2));
Console.WriteLine("20 / 2 = " + proxy.Divide(20, 2));
Console.ReadKey();