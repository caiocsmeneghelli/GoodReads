using GoodReads.Application.UpdateBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

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
    }
}
