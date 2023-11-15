using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.BasePosts.Commands.DeleteBasePost;
using RealEstate.Application.Features.BasePosts.Queries.GetAll;
using RealEstate.Application.Features.BasePosts.Queries.GetById;
using RealEstate.Application.Features.Categories.Commands.CreateBasePost;

namespace RealEstate.API.Controllers
{
    public class BasePostController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateBasePostCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllBasePostsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdBasePostQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteBasePostCommand = new DeleteBasePost() { BasePostId = id };
            await Mediator.Send(deleteBasePostCommand);
            return NoContent();
        }
    }
}
