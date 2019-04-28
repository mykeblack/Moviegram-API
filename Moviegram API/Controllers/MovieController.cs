using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Domain;

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
        public ActionResult<string> Get(string title, int limit, string keyword, string startdate, string enddate)
        {
            try
            {
                using (var mf = new MovieFactory())
                {
                    var list = mf.GetMovies(title, limit, keyword, startdate, enddate);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(list);
                }
            }
            catch (Exception ex) {
                // we could a custom error object to return a json safe error message, but will just create as a string for now.
                return "{error: " + ex.Message + "}";
            }
        }

        // returns details of a single movie
        [Route("/movies/detail")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                using (var mf = new MovieFactory())
                {
                    var movie = mf.GetMovie(id);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(movie);
                }
            }
            catch (Exception ex)
            {
                return "{error: " + ex.Message + "}";
            }
        }




        // ADMIN methods
        // we're not building this part of the application right now, so just return unauthorised message because we have not built in authentication yet.
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
