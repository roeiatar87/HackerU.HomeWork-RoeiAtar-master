using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demos.HackerU.ServerAPI.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        public TodosController()
        {

        }

        // GET: api/<TodosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "XXXX", "YYYY", "ZZZZ", "VVVV" };
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Client Send Param:" + id + ",ServerTime Is:" + DateTime.Now;
        }

        // POST api/<TodosController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "Client Post Data:" + value.ToLower() + ",ServerTime Is:" + DateTime.Now;
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
