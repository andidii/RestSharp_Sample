using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_Sample.Controller;
using Selenium_Sample.Factories;
using Selenium_Sample.Models;
using Selenium_Sample.Support;
using System.Linq;
using TechTalk.SpecFlow;

namespace Selenium_Sample.StepDefinitions
{
    [Binding]
    public class BasicSteps
    {

        [Given(@"I open test page")]
        public void GivenIOpenTestPage()
        {
            DriverHelper.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            BasicControl.GetElement(TestPageObjects.loginButtonXpath, Common.SearchCriteriaEnum.XPath).Click();
        }

        [Then(@"I see CreateAccount section")]
        public void ThenISeeCreateAccountSection()
        {
            Assert.IsTrue(BasicControl.GetElement(TestPageObjects.createAccountFormXpath, Common.SearchCriteriaEnum.XPath).Displayed);
        }

        [When(@"I enter ""(.*)"" into email address input")]
        public void WhenIEnterIntoEmailAddressInput(string email)
        {
            BasicControl.GetElement(TestPageObjects.createAccountEmailInputXpath, Common.SearchCriteriaEnum.XPath).SendKeys(email);
        }

        [When(@"I Click on Create Account button")]
        public void WhenIClickOnCreateAccountButton()
        {
            BasicControl.GetElement(TestPageObjects.createAccountButtonXpath, Common.SearchCriteriaEnum.XPath).Click();
        }

        [Then(@"I am redirected to create account form")]
        public void ThenIAmRedirectedToCreateAccountForm()
        {
            BasicControl.WaitUntilPageIsFullyLoaded();
            Assert.IsTrue(BasicControl.GetElement(TestPageObjects.accountCreationFormXpath, Common.SearchCriteriaEnum.XPath).Displayed);
        }

        [When(@"I fill create account form with data as ""(.*)""")]
        public void WhenIFillCreateAccountFormWithDataAs(string account)
        {
            var selectedUser = new TestData().Customers.FirstOrDefault(x => string.Equals(x.PersonalFirstName, account));
            System.Console.WriteLine(selectedUser.PersonalFirstName);

            BasicControl.GetElement(TestPageObjects.accountCreationFormFirstNameXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.PersonalFirstName);
            BasicControl.GetElement(TestPageObjects.accountCreationFormLastNameXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.PersonalLastName);
            BasicControl.GetElement(TestPageObjects.accountCreationPasswordXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Personalpassword);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressFirstNameXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addressfirstname);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressLastNameXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addresslastname);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addressaddress);

            BasicControl.MoveToElement(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressAliasXpath, Common.SearchCriteriaEnum.XPath));

            Actions actions = new Actions(DriverHelper.Driver);
            actions.MoveToElement(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressStateXpath, Common.SearchCriteriaEnum.XPath));
            actions.Click().Build().Perform();

            BasicControl.GetElement(TestPageObjects.stateSelect, Common.SearchCriteriaEnum.XPath).Click();

            BasicControl.GetElement(TestPageObjects.accountCreationFormZipXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addresszip);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressCityXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addresscity);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressPhoneNumberXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addressphone);
            BasicControl.GetElement(TestPageObjects.accountCreationFormAddressAliasXpath, Common.SearchCriteriaEnum.XPath).SendKeys(selectedUser.Addressalias);
        }

        [Then(@"I see form is filled")]
        public void ThenISeeFormIsFilled()
        {
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormFirstNameXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormLastNameXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressFirstNameXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressLastNameXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressPhoneNumberXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
            Assert.IsNotEmpty(BasicControl.GetElement(TestPageObjects.accountCreationFormAddressLastNameXpath, Common.SearchCriteriaEnum.XPath).GetAttribute("value"));
        }

        [When(@"I click Register")]
        public void WhenIClickRegister()
        {
            BasicControl.MoveToElement(BasicControl.GetElement(TestPageObjects.accountCreationFormRegisterButtonXpath, Common.SearchCriteriaEnum.XPath));
            BasicControl.GetElement(TestPageObjects.accountCreationFormRegisterButtonXpath, Common.SearchCriteriaEnum.XPath).Click();
        }

        [Then(@"I see user is registered ""(.*)""")]
        public void ThenISeeUserIsRegistered(string name)
        {
            BasicControl.WaitForElement(TestPageObjects.userInfo, Common.SearchCriteriaEnum.XPath);
            Assert.That(BasicControl.GetElement(TestPageObjects.userInfo, Common.SearchCriteriaEnum.XPath).Text, Does.Contain(name));
        }

    }
}
