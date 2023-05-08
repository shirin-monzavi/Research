namespace LiskovTestSample
{
    public class Dog : Animal
    {
        public Dog(int weight) : base(weight)
        {
        }

        public override int CalculateDozeOfMedicine()
        {
            return base.CalculateDozeOfMedicine();
        }
    }
}
