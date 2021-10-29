using OpenQA.Selenium.Chrome;
using Selenium_Sample.Factories;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Sample.Support
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddArgument("ignore-certificate-errors");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            DriverHelper.Driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.Driver.Quit();
        }


    }
}
