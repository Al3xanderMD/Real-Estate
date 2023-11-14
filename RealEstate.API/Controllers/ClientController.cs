using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Categories.Commands.CreateClient;

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
    }
}
