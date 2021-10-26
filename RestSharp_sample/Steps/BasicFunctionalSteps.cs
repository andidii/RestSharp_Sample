using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp_sample.FunctionalTests.Controller;
using RestSharp_sample.FunctionalTests.PageObjects;
using RestSharp_sample.Utilities;
using TechTalk.SpecFlow;

namespace RestSharp_sample.Steps
{
    [Binding]
    class BasicFunctionalSteps
    {
        public static IWebDriver driver;

        [Given(@"I open test page")]
        public static void GivenIOpenTestPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Window.Maximize();

            BasicControl.WaitForElement(TestPageObjects.loginButtonXpath, SearchCriteriaEnum.XPath);

            Assert.Equals("My Store", driver.Title);
        }
    }
}
