using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/valuations")]
    public class ValuationsController : ControllerBase
    {
        private readonly IDatabaseService _database;
        
        public ValuationsController(IDatabaseService database)
        {
            _database = database;
        }

        /// <summary>
        ///  A list of MarketValuation with a single item in the list. 
        ///  This item should have a name of "DataValueTotal" and a total of the sum of all currently active MarketData
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketValuation>>> Get()
        {            
            return Ok(await _database.ValuationsAsync());
        }
    }
}