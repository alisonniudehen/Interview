using CanWeFixItApi;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;

namespace CanWeFixItTest
{
    public class ControllerTest
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        public ControllerTest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [SetUp]
        public void Setup()
        {
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task ValuationsController_GetAsync()
        {
            // Arrange
           
            // Act
            var response = await _client.GetAsync("v1/valuations");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<IEnumerable<MarketValuation>>(responseString);
            // Assert
            Assert.AreEqual("DataValueTotal",(responseObject.FirstOrDefault().Name));
            Assert.IsTrue( responseObject.FirstOrDefault().Total>0);
        } 
        [Test]
        public async Task MarketDataController_GetAsync()
        {
            // Arrange
           
            // Act
            var response = await _client.GetAsync("v1/MarketData");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<IEnumerable<MarketData>>(responseString);
            // Assert
            Assert.AreEqual(2, (responseObject.FirstOrDefault(x=>x.Id==2).InstrumentId));
            Assert.IsTrue(responseObject.FirstOrDefault(x => x.Id == 2).Active==true);
        }
        [Test]
        public async Task InstrumentController_GetAsync()
        {
            // Arrange
            
            // Act
            var response = await _client.GetAsync("v1/instruments");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<IEnumerable<Instrument>>(responseString);
            // Assert
            Assert.AreEqual("Sedol2", (responseObject.FirstOrDefault(x => x.Id == 2).Sedol));
            Assert.AreEqual("Name2", (responseObject.FirstOrDefault(x => x.Id == 2).Name));
            Assert.IsTrue(responseObject.FirstOrDefault(x => x.Id == 2).Active == true);
        }
    }
}