using Microsoft.AspNetCore.Mvc;
using _0auth.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using _0auth.DTO;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0auth.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DbTradeContext context;
        private static User? _currentUser { get; set; }
        public AuthController(DbTradeContext context)
        {
            this.context = context;
        }
        [HttpGet("{login}, {password}")]
        public ActionResult<User?> Get(string login, string password)
        {
            User? user = context.Users.Where(user => user.PasswordUser == password && user.LoginUser == login).FirstOrDefault();
            if (user != null)
                _currentUser = user;
            return user == null ? NotFound("Пользователь не найден") : Ok(user);
        }

        // POST api/<AuthController>
        [HttpPost("registration")]
        public ActionResult<User> Register([FromBody] UserDTO userDTO)
        {
            var existingUser = context.Users.FirstOrDefault(u => u.LoginUser == userDTO.LoginUser);
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
            _currentUser = newUser;

            Program.context.Users.Add(newUser);
            Program.context.SaveChanges();
            return StatusCode(201, newUser);
        }
        [HttpGet("current")]
        public ActionResult<User?> GetCurrentUser()
        {
            if (_currentUser != null)
            {
                User? user = context.Users.FirstOrDefault(u => u.IdUser == _currentUser.IdUser);
                return user == null ? NotFound("Пользователь не найден.") : Ok(user);
            }
            else 
                return NotFound();
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO updatedUser)
        {
            if (updatedUser == null || string.IsNullOrWhiteSpace(updatedUser.LoginUser))
            {
                return BadRequest("Некорректные данные пользователя");
            }

            var user = await context.Users
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefaultAsync(u => u.IdUser == updatedUser.IdUser);

            if (user == null)
            {
                return NotFound($"Пользователь с таким ID {updatedUser.IdUser} не найден");
            }

            var role = await context.Roles.FindAsync(updatedUser.IdRole);
            if (role == null)
            {
                return NotFound($"Роль с ID {updatedUser.IdRole} не найдена");
            }

            user.SurnameUser = updatedUser.SurnameUser ?? user.SurnameUser;
            user.NameUser = updatedUser.NameUser ?? user.NameUser;
            user.PatronymicUser = updatedUser.PatronymicUser ?? user.PatronymicUser;
            user.PasswordUser = updatedUser.PasswordUser ?? user.PasswordUser;
            user.IdRole = updatedUser.IdRole;

            try
            {
                await context.SaveChangesAsync();
                return Ok("Пользователь успешно обновлен");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Ошибка при обновлении пользователя: {ex.Message}");
            }
        }
    }
}
