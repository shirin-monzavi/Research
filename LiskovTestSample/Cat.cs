namespace LiskovTestSample
{
    public class Cat : Animal
    {
        public Cat(int weight) : base(weight)
        {
        }

        public override int CalculateDozeOfMedicine()
        {
            return base.CalculateDozeOfMedicine();
        }
    }
}
