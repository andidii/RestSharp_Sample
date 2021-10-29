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

        public TestData()
        {
            Customers = FormCustomer();
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
    }
}
