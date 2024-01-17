using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.BasePosts.Queries.GetAll;
using RealEstate.Application.Features.Posts.Commands.CreatePost;
using RealEstate.Application.Features.Posts.Commands.DeletePost;
using RealEstate.Application.Features.Posts.Commands.UpdatePost;
using RealEstate.Application.Features.Posts.Queries.GetAll;
using RealEstate.Application.Features.Posts.Queries.GetById;

namespace RealEstate.API.Controllers
{
	public class PostController : ApiControllerBase
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Create(CreatePostCommand command)
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
			var result = await Mediator.Send(new GetAllPostsQuery());
			return Ok(result);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await Mediator.Send(new GetByIdPostQuery(id));
			return Ok(result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update(int id, UpdatePostCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			var result = await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeletePost { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
