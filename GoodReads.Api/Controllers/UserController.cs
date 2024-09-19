using GoodReads.Application.Commands.Users.CreateUser;
using GoodReads.Application.Queries.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);
            var user = await _mediator.Send(command);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) { return BadRequest(result); }

            return CreatedAtAction(nameof(GetById), command, result);
        }
    }
}
