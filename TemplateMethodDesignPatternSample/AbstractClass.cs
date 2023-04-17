namespace TemplateMethodDesignPatternSample
{
    public abstract class AbstractClass
    {
        public void GetLoan()
        {
            Console.WriteLine("Welcome");

            RegisterUser();
            UploadDocuments();
            GetLoanAmount();
            GetGuarantors();
            InTheProceedingStep();
        }

        protected void RegisterUser()
        {
            Console.WriteLine("The Use has been registered");
        }

        protected void UploadDocuments()
        {
            Console.WriteLine("documents have been received");
        }

        protected abstract void GetLoanAmount();

        protected void GetGuarantors()
        {
            Console.WriteLine("Guarantors are received");
        }
        protected void InTheProceedingStep()
        {
            Console.WriteLine("The loan is under consideration");
        }

    }
}
