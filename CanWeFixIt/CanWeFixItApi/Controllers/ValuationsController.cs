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
        
        // GET
        public async Task<ActionResult<IEnumerable<MarketValuation>>> Get()
        {
            var a = (await _database.ValuationsAsync()).ToList();
            return Ok(await _database.ValuationsAsync());
        }
    }
}