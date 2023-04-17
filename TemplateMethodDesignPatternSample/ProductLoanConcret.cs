namespace TemplateMethodDesignPatternSample
{
    public class ProductLoanConcret : AbstractClass
    {
        protected override void GetLoanAmount()
        {
            Console.WriteLine("The Amount is 10$");
        }
    }
}
