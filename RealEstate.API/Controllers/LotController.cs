using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Lots.Commands.CreateLot;
using RealEstate.Application.Features.Lots.Commands.DeleteLot;
using RealEstate.Application.Features.Lots.Commands.UpdateLot;
using RealEstate.Application.Features.Lots.Queries.GetAll;
using RealEstate.Application.Features.Lots.Queries.GetById;

namespace RealEstate.API.Controllers
{
	public class LotController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateLotCommand command)
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
            var result = await Mediator.Send(new GetAllLotsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdLotQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateLotCommand command)
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
            var deleteLotCommand = new DeleteLot() { Id = id };
            await Mediator.Send(deleteLotCommand);
            return NoContent();
        }
    }
}
