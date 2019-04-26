using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Moviegram_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        // Public methods
        // GET /values
        [Route("/movies/list")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("/movies/detail")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }



        // ADMIN methods
        // we're not building this right now, so just return unauthorised message because we have not build in authentication yet.

        [Authorize]
        [Route("/movies/add")]
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return Unauthorized();
        }

        [Authorize]
        [Route("/movies/update")]
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            return Unauthorized();
        }

        [Authorize]
        [Route("/movies/delete")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return Unauthorized();
        }
    }
}
