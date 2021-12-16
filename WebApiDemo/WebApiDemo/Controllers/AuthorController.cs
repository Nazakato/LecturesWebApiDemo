using Demo.Dal.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.Filters;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorRepository authorRepository, ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        [LogToDebugActionFilter]
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogTrace("Trace level logging from GetAllAuthors!");
            _logger.LogInformation("Info level logging from GetAllAuthors!");
            _logger.LogError("Error level logging from GetAllAuthors!");
            _logger.Log(LogLevel.Warning, "Warning level logging from GetAllAuthors!");
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
            var model = new Author { Id = id, Name = name };
            _authorRepository.CreateAuthor(model);
            return Created("/author/" + id, model);
        }
    }
}