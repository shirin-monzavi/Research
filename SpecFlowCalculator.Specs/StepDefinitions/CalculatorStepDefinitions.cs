using FluentAssertions;

namespace SpecFlowCalculator.Specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions : Steps
    {
        private readonly Calculator _calculator = new Calculator();
        private readonly ScenarioContext _senarioContext;
        private int _result;

        public CalculatorStepDefinitions(ScenarioContext senarioContext)
        {
            _senarioContext = senarioContext;
        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            _calculator.FirstNumber = 0;
            _calculator.SecondNumber = 0;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();

            _senarioContext.Add("result", _result);
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = _calculator.Subtract();
            _senarioContext.Add("result", _result);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            var findResult = _senarioContext.Get<int>("result");

            findResult.Should().Be(result);
        }


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int first)
        {
            _calculator.FirstNumber = first;
        }


        [Given(@"I also have entered (.*) into the calculator")]
        public void GivenIAlsoHaveEnteredIntoTheCalculator(int second)
        {
            _calculator.SecondNumber = second;
        }

        [When(@"I press add button")]
        public void WhenIPressAddButton()
        {
            _result = _calculator.Divide();

            _senarioContext.Add("result", _result);
        }

        [Then(@"the result must be (.*) on the screen")]
        public void ThenTheResultMustBeOnTheScreen(int result)
        {
            _result.Should().Be(result);
        }

        [Given(@"the first number (.*) is defined")]
        public void GivenTheFirstNumberIsDefined(int p0)
        {
            Given(String.Format("the first number is {0}", p0));
        }

        [Given(@"the second number (.*) is defined")]
        public void GivenTheSecondNumberIsDefined(int p0)
        {
            Given(String.Format("the second number is {0}", p0));
        }

        [When(@"I press multiply button")]
        public void WhenIPressMultiplyButton()
        {
            _result = _calculator.multiply();

            _senarioContext.Add("result", _result);
        }

    }
}