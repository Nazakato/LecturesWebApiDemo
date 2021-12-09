using Demo.Dal.Authors;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;

namespace WebApiDemo.Controllers
{
    [CustomExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [AddTimestampActionFilter]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorRepository.GetAllAuthors());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_authorRepository.GetAuthor(id));
        }

        [HttpGet("create")]
        public IActionResult Create([FromQuery]int id, [FromQuery]string name)
        {
            _authorRepository.CreateAuthor(new Author { Id = id, Name = name });
            return Ok();
        }
    }
}