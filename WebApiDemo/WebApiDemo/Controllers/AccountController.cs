using Demo.Administration.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebApiDemo.Filters;
using WebApiDemo.Helpers;
using WebApiDemo.Models.Account;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ModelStateActionFilter]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AccountController(
            IUserService userService,
            IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
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

            var roles = await _userService.GetRoles(user);

            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
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