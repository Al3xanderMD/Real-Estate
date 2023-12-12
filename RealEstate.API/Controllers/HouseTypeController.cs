using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType;
using RealEstate.Application.Features.HouseTypes.Commands.DeleteHouseType;
using RealEstate.Application.Features.HouseTypes.Commands.UpdateHouseType;
using RealEstate.Application.Features.HouseTypes.Queries.GetAll;
using RealEstate.Application.Features.HouseTypes.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class HouseTypeController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateHouseTypeCommand command)
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
            var result = await Mediator.Send(new GetAllHouseTypesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdHouseTypeQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateHouseTypeCommand command)
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
            var deleteHouseTypeCommand = new DeleteHouseType() { Id = id };
            await Mediator.Send(deleteHouseTypeCommand);
            return NoContent();
        }
    }
}
