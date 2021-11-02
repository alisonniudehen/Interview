using CanWeFixItApi;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CanWeFixItTest
{
    public class ControllerTest
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ControllerTest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task MarketValuationController_GetAsync()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("v1/MarketValuation");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<IEnumerable<MarketValuation>>(responseString);
            // Assert
            Assert.AreEqual("DataValueTotal",(responseObject.FirstOrDefault().Name));
            Assert.IsTrue( responseObject.FirstOrDefault().Total>0);
        }
    }
}