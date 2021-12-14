using Demo.Administration.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo.Filters;
using WebApiDemo.Models.Account;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ModelStateActionFilter]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _userService.Register(new Register
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Year = model.Year
            });

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon(LogonModel model)
        {
            var user = await _userService.Logon(new Logon
            {
                Email = model.Email,
                Password = model.Password
            });

            if (user is null) return BadRequest();

            return Ok();
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            await _userService.CreateRole(model.RoleName);
            return Ok();
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetRoles());
        }

        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(AssignUserToRoleModel model)
        {
            await _userService.AssignUserToRoles(new AssignUserToRoles
            {
                Email = model.Email,
                Roles = model.Roles
            });

            return Ok();
        }
    }
}