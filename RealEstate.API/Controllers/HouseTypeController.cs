using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType;
using RealEstate.Application.Features.HouseTypes.Queries.GetAll;
using RealEstate.Application.Features.HouseTypes.Queries.GetById;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllHouseTypesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdHouseTypeQuery(id));
            return Ok(result);
        }
    }
}
