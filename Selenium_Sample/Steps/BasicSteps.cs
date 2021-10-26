using OpenQA.Selenium;
using Selenium_Sample.Common;
using Selenium_Sample.Controller;
using Selenium_Sample.Models;
using TechTalk.SpecFlow;

namespace Selenium_Sample.Steps
{
    [Binding]
    public class BasicSteps
    {
        public static IWebDriver driver;

        public BasicSteps(ScenarioContext scenarioContex)
        {
            driver = scenarioContex["driver"] as IWebDriver;
        }

        [Given(@"I open test page")]
        public void GivenIOpenTestPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            driver.Manage().Window.Maximize();

            BasicControl.WaitForElement(TestPageModel.loginButtonXpath, SearchCriteriaEnum.XPath);
        }

    }
}
