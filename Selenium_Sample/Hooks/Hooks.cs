using OpenQA.Selenium;
using Selenium_Sample.Factories;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Selenium_Sample.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static string ConfigDriver = ConfigurationManager.AppSettings["Driver"];
        private IWebDriver driver;
        ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Enum.TryParse(ConfigDriver, out DriverType driverType);
            driver = DriverFactory.ReturnDriver(driverType);
            _scenarioContext["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
