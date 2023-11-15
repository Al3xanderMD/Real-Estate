using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.LotClassifications.CreateLotClassifications;
using RealEstate.Application.Features.LotClassifications.Queries.GetAll;
using RealEstate.Application.Features.LotClassifications.Queries.GetById;

namespace RealEstate.API.Controllers
{

    public class LotClassificationController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateLotClassificationCommand command)
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
            var result = await Mediator.Send(new GetAllLotClassificationsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdLotClassificationQuery(id));
            return Ok(result);
        }
    }
}
