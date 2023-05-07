public class Calculator
{
    public int FirstNumber { get; set; }

    public int SecondNumber { get; set; }

    public int Add()
    {
        return FirstNumber + SecondNumber;
    }

    public int Subtract()
    {
        return FirstNumber - SecondNumber;
    }

    public int Divide()
    {
        return FirstNumber / SecondNumber;
    }

    public int multiply()
    {
        return FirstNumber * SecondNumber;
    }
}