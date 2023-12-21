﻿using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.DeleteApartment
{
    public class DeleteApartment : IRequest<DeleteApartmentResponse>
    {
        public Guid BasePostId { get; set; }
    }
}
