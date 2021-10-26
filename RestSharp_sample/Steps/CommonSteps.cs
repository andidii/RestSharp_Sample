using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace RestSharp_sample.Steps
{
    [Binding]
    public static class CommonSteps
    {
        public static IWebDriver driver { get; set; }

        public static void Initialize(ScenarioContext scenarioContex)
        {
            driver = scenarioContex["driver"] as IWebDriver;
        }

        

    }
}
