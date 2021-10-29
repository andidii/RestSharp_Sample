using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_Sample.Common;
using Selenium_Sample.Factories;
using SeleniumExtras.WaitHelpers;
using System;

namespace Selenium_Sample.Controller
{
    public static class BasicControl
    {
        public static IWebElement GetElement(string locator, SearchCriteriaEnum searchCriteria, int waitInSeconds = 60)
        {
            WaitForElement(locator, searchCriteria, waitInSeconds);
            var element = DriverHelper.Driver.FindElement(FindBy(locator, searchCriteria));
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

        public static void WaitForElement(string locator, SearchCriteriaEnum searchCriteria, int waitInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(DriverHelper.Driver, new TimeSpan(0, 0, waitInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(FindBy(locator, searchCriteria)));
        }

        public static void ClearField(IWebElement element)
        {
            while (!element.GetAttribute("value").Equals(""))
            {
                element.Click();
                element.SendKeys(Keys.Backspace);
            }
        }

        public static void WaitUntilPageIsFullyLoaded()
        {
            new WebDriverWait(DriverHelper.Driver, new TimeSpan(0, 0, 60)).Until(x => (((IJavaScriptExecutor)DriverHelper.Driver).ExecuteScript("return document.readyState").ToString() == "complete"));
        }

        public static void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(DriverHelper.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
