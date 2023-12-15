using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Houses.Commands.CreateHouse;
using RealEstate.Application.Features.Houses.Commands.DeleteHouse;
using RealEstate.Application.Features.Houses.Commands.UpdateHouse;
using RealEstate.Application.Features.Houses.Queries.GetAll;
using RealEstate.Application.Features.Houses.Queries.GetById;

namespace RealEstate.API.Controllers
{
	public class HousesController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateHouseCommand command)
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
            var result = await Mediator.Send(new GetAllHousesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdHouseQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateHouseCommand command)
        {
			if (id != command.Id)
            {
				return BadRequest();
			}
			await Mediator.Send(command);
			return NoContent();
		}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteHouseCommand = new DeleteHouse() { Id = id };
            await Mediator.Send(deleteHouseCommand);
            return NoContent();
        }
    }
}
