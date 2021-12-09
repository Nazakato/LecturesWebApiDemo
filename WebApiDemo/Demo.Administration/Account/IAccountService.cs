using Demo.Administration.Account.Register;
using System.Threading.Tasks;

namespace Demo.Administration.Account
{
    public interface IUserService
    {
        public Task Register(RegisterModel user);
    }
}
