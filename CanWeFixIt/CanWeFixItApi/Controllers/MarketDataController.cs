using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/marketdata")]
    public class MarketDataController : ControllerBase
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public MarketDataController(IDatabaseService database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        /// <summary>
        /// A list of MarketData from the database that are currently active and also have a calculated instrumentId.
        /// The instrumentId should be calculated by looking up the sedol of the marketData against the sedol of the instrument.
        /// So "Sedol2" would be mapped against InstrumentId 
        /// 2 since that instrument has the sedol of "Sedol2". If there is no matching instrument it shouldn't be returned by this endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            var marketDatas = (await _database.MarketDataAsync());

            var marketDataDtos = _mapper.Map<MarketDataDto[]>(marketDatas);
            return Ok(marketDataDtos);
        }
    }
}