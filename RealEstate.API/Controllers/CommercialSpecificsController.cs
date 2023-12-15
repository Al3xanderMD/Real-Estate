using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific;
using RealEstate.Application.Features.CommercialSpecifics.Commands.DeleteCommercialSpecific;
using RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific;
using RealEstate.Application.Features.CommercialSpecifics.Queries.GetAll;
using RealEstate.Application.Features.CommercialSpecifics.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class CommercialSpecificsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCommercialSpecificCommand command)
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
            var result = await Mediator.Send(new GetAllCommercialSpecificsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdCommercialSpecificQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateCommercialSpecificCommand command)
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
            var deleteCommercialSpecificCommand = new DeleteCommercialSpecific() { CommercialSpecificId = id };
            await Mediator.Send(deleteCommercialSpecificCommand);
            return NoContent();
        }
    }
}
