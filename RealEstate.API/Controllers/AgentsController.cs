using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Agents.Commands.CreateAgent;
using RealEstate.Application.Features.Agents.Commands.DeleteAgent;
using RealEstate.Application.Features.Agents.Queries.GetAll;
using RealEstate.Application.Features.Agents.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class AgentsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAgentCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAgentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdAgentsQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteAgentCommand = new DeleteAgent() { Id = id };
            await Mediator.Send(deleteAgentCommand);
            return NoContent();
        }
    }
}
