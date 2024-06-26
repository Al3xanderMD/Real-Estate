﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Addresses.Commands.CreateAddress;
using RealEstate.Application.Features.Addresses.Commands.DeleteAddres;
using RealEstate.Application.Features.Addresses.Commands.UpdateAddress;
using RealEstate.Application.Features.Addresses.Queries.GetAll;
using RealEstate.Application.Features.Addresses.Queries.GetById;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAddressesQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdAddressQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteAddressCommand = new DeleteAddressCommand() { Id = id };
            await Mediator.Send(deleteAddressCommand);
            return NoContent();
        }
    }
}
