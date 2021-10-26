using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp_sample.Steps;
using RestSharp_sample.Utilities;
using System;

namespace RestSharp_sample.FunctionalTests.Controller
{
    public static class BasicControl
    {
        public static IWebElement GetElement(string locator, SearchCriteriaEnum searchCriteria, int waitInSeconds = 30)
        {
            WaitForElement(locator, searchCriteria, waitInSeconds);
            var element = BasicFunctionalSteps.driver.FindElement(FindBy(locator, searchCriteria));
            return element;
        }
        public static By FindBy(string locator, SearchCriteriaEnum searchCriteria)
        {
            if (searchCriteria == SearchCriteriaEnum.CssSelector)
            {
                var findBy = By.CssSelector(locator);
                return findBy;
            }
            else if (searchCriteria == SearchCriteriaEnum.XPath)
            {
                var findBy = By.XPath(locator);
                return findBy;
            }
            else if (searchCriteria == SearchCriteriaEnum.Id)
            {
                var findBy = By.Id(locator);
                return findBy;
            }
            return null;
        }

        public static void WaitForElement(string locator, SearchCriteriaEnum searchCriteria, int waitInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(BasicFunctionalSteps.driver, new TimeSpan(0, 0, waitInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(FindBy(locator, searchCriteria)));
        }
    }
}
