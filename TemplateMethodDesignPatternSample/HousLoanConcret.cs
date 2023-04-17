namespace TemplateMethodDesignPatternSample
{
    public class HousLoanConcret:AbstractClass
    {
        protected override void GetLoanAmount()
        {
            Console.WriteLine("The Amount is 20$");
        }
    }
}
