using GoodReads.Application.Commands.Books.DeleteBook;
using GoodReads.Application.Commands.Books.UpdateBook;
using GoodReads.Application.Queries.Books.GetAllBooks;
using GoodReads.Application.Queries.Books.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpGet("{idBook}")]
        public async Task<IActionResult> GetById(int idBook)
        {
            var query = new GetBookByIdQuery(idBook);
            var book = await _mediator.Send(query);
            if (book == null) { return NotFound(); }

            return Ok(book);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBooksQuery();
            var books = await _mediator.Send(query);
            
            return Ok(books);
        }


        [HttpPut("{idBook}")]
        public async Task<IActionResult> Update([FromRoute]int idBook, [FromBody]UpdateBookCommand command)
        {
            command.IdBook = idBook;
            var result = await _mediator.Send(command);
            if(result.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(result.Errors);
            }

            if(result.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);

            if(result.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result.Errors);
            }

            return NoContent();
        }
    }
}
