using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Commercials.Commands.CreateCommercial;
using RealEstate.Application.Features.Commercials.Commands.DeleteCommercial;
using RealEstate.Application.Features.Commercials.Queries.GetAll;
using RealEstate.Application.Features.Commercials.Queries.GetById;

namespace RealEstate.API.Controllers
{
	public class CommercialsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCommercialCommand command)
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
            var result = await Mediator.Send(new GetAllCommercialsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdCommercialQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCommercialCommand = new DeleteCommercial() { Id = id };
            await Mediator.Send(deleteCommercialCommand);
            return NoContent();
        }
    }
}
