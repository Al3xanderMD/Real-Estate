using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Agents.Commands.CreateAgent;
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
       
    }
}
