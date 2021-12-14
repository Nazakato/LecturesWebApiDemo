using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Administration.Account
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager)//, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
        }

        public async Task Register(Register user)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }, user.Password);

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
        }

        public async Task<ApplicationUser> Logon(Logon logon)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == logon.Email);
            if (user is null) return null;

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? user : null;
        }
    }
}
