using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
 
        [Required]
        public int Year { get; set; }
 
        [Required]
        public string Password { get; set; }
 
        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
