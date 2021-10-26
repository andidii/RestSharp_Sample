using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_Sample.Common;
using Selenium_Sample.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Sample.Controller
{
    class BasicControl
    {
        public static void WaitForElementToAppearAndDisappear(By element, int timeToAppear = 30, int timeToDisappear = 30)
        {
            new WebDriverWait(BasicSteps.driver, new TimeSpan(0, 0, timeToAppear)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if (BasicSteps.driver.FindElement(element).Displayed)
            {
                new WebDriverWait(BasicSteps.driver, new TimeSpan(0, 0, timeToDisappear)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(element));
            }
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
            WebDriverWait wait = new WebDriverWait(BasicSteps.driver, new TimeSpan(0, 0, waitInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(FindBy(locator, searchCriteria)));
        }

        public static IWebElement GetElement(string locator, SearchCriteriaEnum searchCriteria, int waitInSeconds = 30)
        {
            WaitForElement(locator, searchCriteria, waitInSeconds);
            var element = BasicSteps.driver.FindElement(FindBy(locator, searchCriteria));
            return element;
        }
    }
}
