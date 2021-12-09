using Demo.Administration.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo.Filters;
using WebApiDemo.Models.Account;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ModelStateActionFilter]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _userService.Register(new Demo.Administration.Account.Register.RegisterModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Year = model.Year
            });

            return Ok();
        }
    }
}