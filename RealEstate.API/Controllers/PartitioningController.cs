using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Apartments.Commands.CreatePartitioning;

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
    }
}
