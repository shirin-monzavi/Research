namespace LiskovTestSample
{
    public abstract class Animal
    {
        public int Weight { get; }

        public Animal(int weight)
        {
            Weight = weight;
        }

        public virtual int CalculateDozeOfMedicine()
        {
            return Weight * 2;
        }
    }
}
