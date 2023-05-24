namespace OrderDecoratorDesignPatternSample
{
    public abstract class OrderBase
    {
        public abstract double CalculateTotalOrderPrice();
    }

    public class RegularOrder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return 10;
        }
    }

    public class Preorder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a preorder.");
            return 9;
        }
    }

    public class OrderDecorator : OrderBase
    {
        protected OrderBase order;

        public OrderDecorator(OrderBase order)
        {
            this.order = order;
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in a decorator class");
            return order.CalculateTotalOrderPrice();
        }
    }

    public class PremiumPreorder : OrderDecorator
    {
        public PremiumPreorder(OrderBase order)
            : base(order)
        {
        }

        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine($"Calculating the total price in the {nameof(PremiumPreorder)} class.");
            var preOrderPrice = base.CalculateTotalOrderPrice();

            Console.WriteLine("Adding additional discount to a preorder price");
            return preOrderPrice * 0.9;
        }
    }
}