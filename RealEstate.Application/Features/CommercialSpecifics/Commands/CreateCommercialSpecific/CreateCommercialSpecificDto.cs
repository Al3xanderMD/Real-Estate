﻿using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
    public class CreateCommercialSpecificDto
    {
        public Guid CommercialSpecificId { get; set; }
        public string SpecificName { get; set; }
        public Guid CommercialCategoryId { get; set; }
        public CommercialCategory CommercialCategory { get; set; }
    }
}