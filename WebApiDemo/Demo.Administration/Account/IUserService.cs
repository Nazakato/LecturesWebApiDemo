using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Administration.Account
{
    public interface IUserService
    {
        Task Register(Register user);
        Task<ApplicationUser> Logon(Logon logon);
        Task AssignUserToRoles(AssignUserToRoles assignUserToRoles);
        Task CreateRole(string roleName);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
