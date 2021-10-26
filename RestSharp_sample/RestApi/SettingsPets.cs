using RestSharp;
using System;

namespace RestSharp_sample.RestApi
{
    class SettingsPets
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse Response { get; set; }
        public RestRequest Request { get; set; }
        public RestClient RestClient { get; set; }
        public string PetId { get; set; }
    }
}
