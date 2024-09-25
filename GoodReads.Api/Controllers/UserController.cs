using GoodReads.Application.Commands.Users.CreateUser;
using GoodReads.Application.Commands.Users.DeleteUser;
using GoodReads.Application.Commands.Users.UpdateUser;
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

            //return CreatedAtAction(nameof(GetById), command, result.Value);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            command.IdUser = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound(result);
                }
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) { return NotFound(result); }

            return Ok(result);
        }
    }
}
