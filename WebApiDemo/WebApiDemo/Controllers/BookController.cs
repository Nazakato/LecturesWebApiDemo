using Demo.Dal.Books;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [CustomExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookRepository.GetAllBooks());
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateBookModel model)
        {
            _bookRepository.CreateBook(new Book { Id = model.Id, Name = model.Name });
            return Ok();
        }
    }
}