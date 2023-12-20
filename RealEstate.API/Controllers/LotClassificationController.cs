using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.LotClassifications.Command.DeleteLotClassification;
using RealEstate.Application.Features.LotClassifications.Commands.UpdateLotClassification;
using RealEstate.Application.Features.LotClassifications.CreateLotClassifications;
using RealEstate.Application.Features.LotClassifications.Queries.GetAll;
using RealEstate.Application.Features.LotClassifications.Queries.GetById;

namespace RealEstate.API.Controllers
{

    public class LotClassificationController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateLotClassificationCommand command)
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
            var result = await Mediator.Send(new GetAllLotClassificationsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdLotClassificationQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateLotClassificationCommand command)
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
            var deleteLotClassificationCommand = new DeleteLotClassification() { Id = id };
            await Mediator.Send(deleteLotClassificationCommand);
            return NoContent();
        }
    }
}
