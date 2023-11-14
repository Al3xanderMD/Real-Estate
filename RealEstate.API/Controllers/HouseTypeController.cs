using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType;

namespace RealEstate.API.Controllers
{
    public class HouseTypeController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateHouseTypeCommand command)
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
