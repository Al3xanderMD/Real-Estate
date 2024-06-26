﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory;
using RealEstate.Application.Features.CommercialCategories.Commands.DeleteCommercialCategory;
using RealEstate.Application.Features.CommercialCategories.Commands.UpdateCommercialCategory;
using RealEstate.Application.Features.CommercialCategories.Queries.GetAll;
using RealEstate.Application.Features.CommercialCategories.Queries.GetById;

namespace RealEstate.API.Controllers
{
    public class CommercialCategoriesController :ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCommercialCategoryCommand command)
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
            var result = await Mediator.Send(new GetAllCommercialCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdCommercialCategoryQuery(id));
            return Ok(result);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateCommercialCategoryCommand command)
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
            var deleteCommercialCategoryCommand = new DeleteCommercialCategory() { Id = id };
            await Mediator.Send(deleteCommercialCategoryCommand);
            return NoContent();
        }
    }
}
