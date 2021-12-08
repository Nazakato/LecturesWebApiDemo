using Demo.Dal.Authors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorRepository.GetAllAuthors());
        }
    }
}