
using CanWeFixItService;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace CanWeFixItTest
{
    public class ServiceTest
    {
        private DatabaseService _service;

        public ServiceTest()
        {
            _service = new DatabaseService();
            _service?.SetupDatabase();
        }

        [SetUp]
        public void Setup()
        {          
        }

        [Test]
        public async Task DatabaseService_InstrumentsAsync_ReturnOnlyActiveData()
        {
            // Arrange in Setup            
            // Act
            var instruments = await _service.InstrumentsAsync();            
            // Assert          
            Assert.IsTrue(instruments.Count()> 0);
            Assert.IsFalse(instruments.Any(x=>!x.Active));
        }
        [Test]
        public async Task DatabaseService_MarketDataAsync_ReturnOnlyActiveData()
        {
            // Arrange in Setup            
            // Act          
            var marketDatas = await _service.MarketDataAsync(); 

            // Assert          
            Assert.IsTrue(marketDatas.Count() > 0);
            Assert.IsFalse(marketDatas.Any(x => !x.Active));
        }

        [Test]
        public async Task DatabaseService_MarketDataAsync_ReturnRightInstrumentId()
        {
            // Arrange in Setup            
            // Act
            var instruments = await _service.InstrumentsAsync();
            var marketDatas = await _service.MarketDataAsync();

            var marketData = marketDatas.FirstOrDefault();
            var instrumentId = instruments.FirstOrDefault(x => x.Sedol == marketData.Sedol).Id;

            // Assert
            Assert.AreEqual(instrumentId, marketData.InstrumentId);
        }
        [Test]
        public async Task DatabaseService_ValuationsAsync_ReturnTotalOfDataValueAllActive()
        {
            // Arrange in Setup            
            // Act
            var Valuations = await _service.ValuationsAsync();
            var marketDatas = await _service.AllMarketDataAsync();
            var sumOfActive = marketDatas.Where(x=>x.Active).Sum(x=>x.DataValue); 
            // Assert
            Assert.AreEqual(sumOfActive, Valuations.FirstOrDefault().Total);
        }
        [Test]
        public async Task DatabaseService_MarketDataAsync_CheckData()
        {
            // Arrange in Setup            
            // Act
            var data = (await _service.MarketDataAsync()).ToList();

            // Assert
            Assert.IsTrue(data.Count() == 2);
            Assert.IsTrue(data.All(x => x.Active));
            Assert.IsTrue(data.All(x => x.Id is 2 or 4) && data.All(x => x.InstrumentId is 2 or 4));
        }
        [Test]
        public async Task DatabaseService_InstrumentsAsync_CheckData()
        {
            // Arrange in Setup            
            // Act
            var Valuations = (await _service.InstrumentsAsync()).ToList();

            // Assert
            Assert.IsTrue(Valuations.Count() == 4);
            Assert.IsTrue(Valuations.All(x=>x.Active) && Valuations.All(x=>x.Id is 2 or 4 or 6 or 8));
        }
        [Test]
        public async Task DatabaseService_ValuationsAsync_CheckData()
        {
            // Arrange in Setup            
            // Act
            var Valuations = (await _service.ValuationsAsync()).ToList();

            // Assert
            Assert.IsTrue(Valuations.Count() == 1);
            Assert.IsTrue(Valuations.First().Name == "DataValueTotal" && Valuations.First().Total == 13332);
        }
    }
}