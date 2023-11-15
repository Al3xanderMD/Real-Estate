﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Agents.Commands.CreateAgent;

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
    }
}
