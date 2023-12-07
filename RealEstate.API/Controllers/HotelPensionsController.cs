using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension;
using RealEstate.Application.Features.HotelPensions.Commands.DeleteHotelPension;
using RealEstate.Application.Features.HotelPensions.Queries.GetAll;
using RealEstate.Application.Features.HotelPensions.Queries.GetById;

namespace RealEstate.API.Controllers
{
	public class HotelPensionsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateHotelPensionCommand command)
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
            var result = await Mediator.Send(new GetAllHotelPensionsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdHotelPensionQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteHotelPensionCommand = new DeleteHotelPension() { Id = id };
            await Mediator.Send(deleteHotelPensionCommand);
            return NoContent();
        }
    }
}
