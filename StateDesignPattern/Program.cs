// See https://aka.ms/new-console-template for more information
using StateDesignPattern;

var context = new StockMarketContext();
context.PreOpen();
context.Open();
context.EnqueueOrder();
