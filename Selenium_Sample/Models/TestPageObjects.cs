namespace Selenium_Sample.Models
{
    internal class TestPageObjects
    {
        public const string loginButtonXpath = "//a[@class='login']";
        public const string createAccountFormXpath = "//form[@id='create-account_form']";
        public const string createAccountEmailInputXpath = "//input[@id='email_create']";
        public const string createAccountButtonXpath = "//button[@id='SubmitCreate']";
        public const string accountCreationFormXpath = "//form[@id='account-creation_form']";
        public const string accountCreationFormFirstNameXpath = "//input[@id='customer_firstname']";
        public const string accountCreationFormLastNameXpath = "//input[@id='customer_lastname']";
        public const string accountCreationPasswordXpath = "//input[@id='passwd']";
        public const string accountCreationFormAddressFirstNameXpath = "//input[@id='firstname']";
        public const string accountCreationFormAddressLastNameXpath = "//input[@id='lastname']";
        public const string accountCreationFormAddressXpath = "//input[@id='address1']";
        public const string accountCreationFormAddressCityXpath = "//input[@id='city']";
        public const string accountCreationFormAddressStateXpath = "//div[@id='uniform-id_state']";
        public const string accountCreationFormZipXpath = "//input[@id='postcode']";
        public const string accountCreationFormStateXpath = "//select[@id='id_state']";
        public const string stateSelect = "//select[@id='id_state']/option[3]";
        public const string accountCreationFormAddressPostCodeXpath = "//input[@id='postcode']";
        public const string accountCreationFormAddressPhoneNumberXpath = "//input[@id='phone_mobile']";
        public const string accountCreationFormAddressAliasXpath = "//input[@id='alias']";
        public const string accountCreationFormRegisterButtonXpath = "//button[@id='submitAccount']";
        public const string userInfo = "//div[@class='header_user_info']//span";
    }
}
