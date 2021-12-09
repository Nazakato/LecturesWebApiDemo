using Demo.Dal.Authors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_authorRepository.GetAuthor(id));
        }

        [HttpGet("create")]
        public IActionResult Create([FromQuery]int id, [FromQuery]string name)
        {
            try
            {
                _authorRepository.CreateAuthor(new Author { Id = id, Name = name });
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest(new { id, name });
            }
        }
    }
}