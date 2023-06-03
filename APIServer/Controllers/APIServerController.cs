using Demos.HackerU.HomeWork.HW_20;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIServerController : ControllerBase
    {
        private readonly IUsersRolesRepository usersRepo = null;

        //This constractor is inilized by ASP.NET API
        //IUsersRepository usersRepo is injected as UserDbRepository instance (initilized by asp.NET Injection)
        //UserDbRepository is singelton - same instance for all usages
        public APIServerController(IUsersRolesRepository usersRepo)
        {
            this.usersRepo = usersRepo; //?? throw new ArgumentNullException(nameof(usersRepo));
        }

        // GET: api/<APIServerController>
        [HttpGet]
        public List<User> Get()
        {
            var users = usersRepo.GetAllUsers();
            return users;
        }

        // GET api/<APIServerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<APIServerController>
        [HttpPost]
        public void Post(string userName, string password, string email, string rolename)
        {
            usersRepo.UserRegister(userName, password, email, rolename); ;
        }

        // POST api/<APIServerController>
        [HttpPost("{id}")]
        public void Post(int id, string rolename)
        {
            usersRepo.AddUserToRole(id, rolename);
        }

        // PUT api/<APIServerController>/5
        [HttpPut]
        public void Put([FromBody] int id, string value)
        {

        }

        // DELETE api/<APIServerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
