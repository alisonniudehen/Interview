using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/MarketValuation")]
    public class MarketValuationController : ControllerBase
    {
        private readonly IDatabaseService _database;
        
        public MarketValuationController(IDatabaseService database)
        {
            _database = database;
        }
        
        // GET
        public async Task<ActionResult<IEnumerable<MarketValuation>>> Get()
        {
            var a = (await _database.MarketValuationsAsync()).ToList();
            return Ok(await _database.MarketValuationsAsync());
        }
    }
}