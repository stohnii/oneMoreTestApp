using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Managers;

namespace WebApplication2.Controllers
{
    [Route("stem")]
    [ApiController]
    public class StemsController : Controller
    {
        private readonly IDataSearchManager _searchManager;

        public StemsController(IDataSearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string stem)
        {
            var data = await _searchManager.SearchWordsByStemAsync(stem);

            if (data == null)
                return NotFound();

            return Ok(new {data = data});
        }
    }
}
