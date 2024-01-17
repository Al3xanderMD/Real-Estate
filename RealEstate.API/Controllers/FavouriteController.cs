using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Favourites.Commands.CreateFavourites;
using RealEstate.Application.Features.Favourites.Commands.DeleteFavourites;
using RealEstate.Application.Features.Favourites.Queries.GetAll;
using RealEstate.Application.Features.Favourites.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class FavouriteController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateFavouritesCommand command)
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
            var result = await Mediator.Send(new GetAllFavouritesQuery());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var result = await Mediator.Send(new GetAllFavouritesQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("{basePostId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByBasePostId(Guid basePostId)
        {
            var result = await Mediator.Send(new GetAllFavouritesQuery { BasePostId = basePostId });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdFavouriteQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteFavouritesCommand = new DeleteFavouritesCommand() { Id = id };
            await Mediator.Send(deleteFavouritesCommand);
            return NoContent();
        }
    }
}
