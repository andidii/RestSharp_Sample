using RestSharp_sample.RestApi;
using System;
using TechTalk.SpecFlow;

namespace RestSharp_sample.Hooks
{
    [Binding]
    internal class TestInit
    {
        private SettingsPets settingsPets;

        public TestInit(SettingsPets settingsPets) => this.settingsPets = settingsPets;

        [BeforeScenario]
        public void TestSetup()
        {
            this.settingsPets.RestClient = new RestSharp.RestClient("https://petstore3.swagger.io/api/v3");
        }
    }
}
