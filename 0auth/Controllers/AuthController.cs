using Microsoft.AspNetCore.Mvc;
using _0auth.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using _0auth.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("{login}, {password}")]
        public ActionResult<User?> Get(string login, string password)
        {
            User? user = Program.context.Users.Where(user => user.PasswordUser == password && user.LoginUser == login).FirstOrDefault();
            return user == null ? NotFound("Пользователь не найден") : Ok(user);
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost("registration")]
        public ActionResult<User> Register([FromBody] UserDTO userDTO)
        {
            var existingUser = Program.context.Users.FirstOrDefault(u => u.LoginUser == userDTO.LoginUser);
            if (existingUser != null) { return Conflict("Пользователь с таким логином уже существует."); }

            var newUser = new User
            {
                IdUser = userDTO.IdUser,
                SurnameUser = userDTO.SurnameUser,
                NameUser = userDTO.NameUser,
                PatronymicUser = userDTO.PatronymicUser,
                LoginUser = userDTO.LoginUser,
                PasswordUser = userDTO.PasswordUser,
                IdRole = userDTO.IdRole
            };

            Program.context.Users.Add(newUser);
            Program.context.SaveChanges();
            return StatusCode(201, newUser);
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
