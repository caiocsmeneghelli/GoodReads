using GoodReads.Application.Queries.Review.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
