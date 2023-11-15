using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Apartments.Commands.CreateApartament;
using RealEstate.Application.Features.Apartments.Queries.GetAll;
using RealEstate.Application.Features.Apartments.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class ApartmentsController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateApartmentCommand command)
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
            var result = await Mediator.Send(new GetAllApartmentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdApartmentQuery(id));
            return Ok(result);
        }
    }
}
