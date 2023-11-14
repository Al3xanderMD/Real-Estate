using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Addresses.Commands.CreateAddress;

namespace RealEstate.API.Controllers
{
    public class AddressesController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAddressCommand command)
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
