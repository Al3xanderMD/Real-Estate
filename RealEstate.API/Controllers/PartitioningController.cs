using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning;
using RealEstate.Application.Features.Partitionings.Commands.DeletePartitioning;
using RealEstate.Application.Features.Partitionings.Commands.UpdatePartitioning;
using RealEstate.Application.Features.Partitionings.Queries.GetAll;
using RealEstate.Application.Features.Partitionings.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class PartitioningController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePartitioningCommand command)
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
            var result = await Mediator.Send(new GetAllPartitioningsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdPartitioningQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdatePartitioningCommand command)
        {
            if(id != command.Id)
            {
				return BadRequest();
			}
            await Mediator.Send(command);
            return NoContent();
        }

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletePartitioningCommand = new DeletePartitioning() { Id = id };
            await Mediator.Send(deletePartitioningCommand);
            return NoContent();
        }
    }
}
