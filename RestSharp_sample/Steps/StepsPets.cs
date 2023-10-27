using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp_sample.Models;
using RestSharp_sample.RestApi;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharp_sample.StepsPets
{

    [Binding]
    internal class BasicStepsPets
    {
        private SettingsPets settingsPets;

        public BasicStepsPets(SettingsPets settingsPets) => this.settingsPets = settingsPets;

        [Given(@"I prepare all '(.*)' Pets under '(.*)' endpoint")]
        public void GivenIPrepareAllPetsUnderEndpoint(string status, string url)
        {
            this.settingsPets.Request = new RestRequest(url, Method.Get);
            this.settingsPets.Request.AddHeader("Accept", "application/json");
            this.settingsPets.Request.AddParameter("status", status, ParameterType.QueryString);
        }

        [When(@"I execute call")]
        public void WhenIExecuteCall()
        {
            this.settingsPets.Response = this.settingsPets.RestClient.Execute(this.settingsPets.Request);

        }

        [Then(@"I get response code ""(.*)""")]
        public void ThenIGetResponseCode(int code)
        {
            Assert.AreEqual(code, ((int)this.settingsPets.Response.StatusCode));
        }


        [Then(@"I get list of pets")]
        public void ThenIGetListOfPets()
        {
            var deserializedResponse = JsonConvert.DeserializeObject<List<GetPetsModel>>(this.settingsPets.Response.Content);
            var message = deserializedResponse[0].name;
            System.Console.WriteLine(message);
        }

        [Given(@"I prepare '(.*)' method under '(.*)' endpoint")]
        public void GivenIPreparePOSTMethodUnderEndpoint(Method method, string url)
        {
            this.settingsPets.Request = new RestRequest(url, method);
            this.settingsPets.Request.AddHeader("Accept", "application/json");
        }

        [When(@"I add Request body with new pet")]
        public void WhenIAddRequestBodyWithNewPet()
        {
            var body = new PostPetModel
            {
                id = 200910,
                name = "Ciacho",
                category = new Category
                {
                    id = 1,
                    name = "Dogs"
                },
                photoUrls = new[]
                {
                    "string"
                },
                tags = new Tag[]
                {
                    new Tag
                    {
                        id = 0,
                        name = "myFav"
                    }
                },
                status = "available"
            };
            var serializedBody = JsonConvert.SerializeObject(body);
            this.settingsPets.Request.AddParameter("application/json", serializedBody, ParameterType.RequestBody);
            this.settingsPets.Response = this.settingsPets.RestClient.Execute<PostPetModel>(this.settingsPets.Request);
        }

        [When(@"I add Request body to update pet status")]
        public void WhenIAddRequestBodyToUpdatePetStatus()
        {
            var body = new PostPetModel
            {
                id = 200910,
                name = "Ciacho",
                category = new Category
                {
                    id = 1,
                    name = "Dogs"
                },
                photoUrls = new[]
                {
                    "string"
                },
                tags = new Tag[]
                {
                    new Tag
                    {
                        id = 0,
                        name = "myFav"
                    }
                },
                status = "sold"
            };
            var serializedBody = JsonConvert.SerializeObject(body);
            this.settingsPets.Request.AddParameter("application/json", serializedBody, ParameterType.RequestBody);
            this.settingsPets.Response = this.settingsPets.RestClient.Execute<PostPetModel>(this.settingsPets.Request);
        }

        [Given(@"I prepare Delete endpoint to remove pet")]
        public void GivenIPrepareDeleteEndpointToRemovePet()
        {
            this.settingsPets.Request = new RestRequest("/pet/200910", Method.Delete);
        }



    }
}
