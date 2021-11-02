using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v2/marketdata")]
    public class MarketDataController : ControllerBase
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public MarketDataController(IDatabaseService database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        // GET
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            var marketDatas = (await _database.MarketData());

            var marketDataDtos = _mapper.Map<MarketDataDto[]>(marketDatas);
            return Ok(marketDataDtos);
        }
    }
}