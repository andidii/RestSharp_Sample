using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selenium_Sample.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Selenium_Sample.Support
{
    public class TestData
    {
        public List<Customer> Customers { get; }

        public List<Personal> Personal { get;  }

        public TestData()
        {
            Customers = FormCustomer();
            Personal = FromPersonal();
        }

        public List<Customer> FormCustomer()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream customersStream = assembly.GetManifestResourceStream("Selenium_Sample.Resources.customers.json");

            if (customersStream == null)
                throw new FileNotFoundException("Could not find customers.json resource file");

            var streamReader = new StreamReader(customersStream);
            var jToken = JToken.Parse(streamReader.ReadToEnd());
            var jsonReader = jToken.SelectToken("customers").CreateReader();

            var jsonSerializer = new JsonSerializer();
            var customers = (List<Customer>)jsonSerializer.Deserialize(jsonReader, typeof(List<Customer>));

            return customers;
        }

        public List<Personal> FromPersonal()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream personalStream = assembly.GetManifestResourceStream("Selenium_Sample.Resources.personal.json");

            if (personalStream == null)
                throw new FileNotFoundException("Could not find personal.json resource file");

            var streamReader = new StreamReader(personalStream);
            var jToken = JToken.Parse(streamReader.ReadToEnd());
            var jsonReader = jToken.SelectToken("personal").CreateReader();

            var jsonSerializer = new JsonSerializer();
            var personal = (List<Personal>)jsonSerializer.Deserialize(jsonReader, typeof(List<Personal>));

            return personal;
        }
    }
}
