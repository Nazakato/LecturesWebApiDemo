using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models.Account
{
    public class CreateRoleModel
    {
        [Required, MinLength(5), MaxLength(20)]
        public string RoleName { get; set; }
    }
}
