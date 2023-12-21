using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Categories.Commands.CreateClient;
using RealEstate.Application.Features.Clients.Commands.DeleteClient;
using RealEstate.Application.Features.Clients.Commands.UpdateClient;
using RealEstate.Application.Features.Clients.Queries.GetAll;
using RealEstate.Application.Features.Clients.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class ClientController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateClientCommand command)
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
            var result = await Mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdClientQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateClientCommand command)
        {
            if (id != command.UserId)
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
            var deleteClientCommand = new DeleteClient() { UserId = id };
            await Mediator.Send(deleteClientCommand);
            return NoContent();
        }
    }
}
