using System.Threading.Tasks;

namespace Demo.Administration.Account
{
    public interface IUserService
    {
        Task Register(Register user);
        Task<ApplicationUser> Logon(Logon logon);
    }
}
