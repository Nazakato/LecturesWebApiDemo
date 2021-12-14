using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Administration.Account
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)//, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
            if (user is null) throw new System.Exception($"User not found: '{logon.Email}'.");

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? user : null;
        }

        public async Task AssignUserToRoles(AssignUserToRoles assignUserToRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == assignUserToRoles.Email);
            var roles = _roleManager.Roles.ToList().Where(r => assignUserToRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();

            var result = await _userManager.AddToRolesAsync(user, roles); // THROWS

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
        }

        public async Task CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new System.Exception($"Role could not be created: {roleName}.");
            }
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
