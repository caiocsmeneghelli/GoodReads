using GoodReads.Application.Commands.Reviews.CreateReview;
using GoodReads.Application.Queries.Reviews.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetReviewByIdQuery(id);
            var result = await _mediator.Send(query);
            
            if(result is null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateReviewCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) { return BadRequest(result); }

            return CreatedAtAction(nameof(Get), command, result);
        }
    }
}
