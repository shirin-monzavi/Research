// See https://aka.ms/new-console-template for more information
using IsAssignableFrom;

var p1 = typeof(Person);

Console.WriteLine(p1.IsAssignableFrom(p.GetType()));

Console.WriteLine(p is Person);