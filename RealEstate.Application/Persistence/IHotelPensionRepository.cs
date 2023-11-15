﻿using RealEstate.Application.Contracts;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Persistence
{
    public interface IHotelPensionRepository : IAsyncRepository<HotelPension>
    {
    }
}
