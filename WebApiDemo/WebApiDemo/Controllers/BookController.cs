using Demo.Dal.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [CustomExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        [ModelStateActionFilter]
        public IActionResult Post([FromBody]CreateBookModel model)
        {
            _bookRepository.CreateBook(new Book { Id = model.Id, Name = model.Name });
            return Ok();
        }
    }
}