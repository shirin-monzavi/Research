using BDDSample;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowCalculator.Specs.StepDefinitions
{
    [Binding]
    public class DepositeAccountStepDefinitions
    {
        ScenarioContext _context;
        private readonly AccountManagement _accountManagement;
        private int reault;
        public DepositeAccountStepDefinitions(ScenarioContext context, AccountManagement accountManagement)
        {
            _context = context;
            _accountManagement = accountManagement;
        }
        [Given(@"the below information account is given")]
        public void GivenTheBelowInformationAccountIsGiven(Table table)
        {
            _context.Add("accountInfo", table.CreateInstance<Account>());
        }

        [When(@"I deposite (.*)\$")]
        public void WhenIDeposite(int p0)
        {
            var acc = _context.Get<Account>("accountInfo");
            _accountManagement.Deposite(acc, p0);
        }

        [Then(@"The account should be")]
        public void ThenTheAccountShouldBe(Table table)
        {
            var accountInfo = table.CreateInstance<Account>().BankAccountBalance;
            accountInfo.Should().Be(table.CreateInstance<Account>().BankAccountBalance);
        }
    }
}
