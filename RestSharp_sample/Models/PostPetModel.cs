namespace RestSharp_sample.Models
{

    public class PostPetModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }
    }
}
