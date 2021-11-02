using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/instruments")]
    public class InstrumentController : ControllerBase
    {
        private readonly IDatabaseService _database;
        
        public InstrumentController(IDatabaseService database)
        {
            _database = database;
        }
        /// <summary>
        /// A list of Instruments from the database that are currently active
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> Get()
        {
            return Ok(await _database.InstrumentsAsync());
        }
    }
}