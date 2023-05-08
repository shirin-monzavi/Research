namespace NSubstituteSample
{
    public interface ICalculator
    {
        int Add(int x,int y);
        int Divide(int x, int y, out float remainder);
    }
}
