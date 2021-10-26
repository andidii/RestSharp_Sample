using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using System;

namespace Selenium_Sample.Factories
{
    public static class DriverFactory
    {
        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("ignore-certificate-errors");
                    chromeOptions.AddArgument("--start-maximized");
                    driver = new ChromeDriver(chromeOptions);

                    break;
                case DriverType.Edge:
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                case DriverType.Safari:
                    driver = new SafariDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null);
            }
            return driver;
        }
    }
}
