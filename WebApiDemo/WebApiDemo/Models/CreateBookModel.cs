using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class CreateBookModel
    {
        [Required(ErrorMessage = "Enter your id.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Name.")]
        public string Name { get; set; }
    }
}
