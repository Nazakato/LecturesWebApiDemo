using Microsoft.AspNetCore.Identity;

namespace Demo.Administration
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
