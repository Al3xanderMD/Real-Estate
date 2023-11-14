using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, CreateHouseCommandResponse>
    {
        private readonly IHouseRepository repository;

        public CreateHouseCommandHandler(IHouseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<CreateHouseCommandResponse> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHouseCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateHouseCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var house = House.Create(request.BasePostId, request.RoomCount, request.FloorCount, request.UsefulSurface, request.LotArea, request.BuildYear, request.HouseTypeId);

            if (!house.IsSuccess)
            {
                return new CreateHouseCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { house.Error }
                };
            }

            await repository.AddAsync(house.Value);

            return new CreateHouseCommandResponse
            {
                Success = true,
                House = new CreateHouseDTO
                {
                    Id = house.Value.Id,
                    RoomCount = house.Value.RoomCount,
                    FloorCount = house.Value.FloorCount,
                    UsefulSurface = house.Value.UsefulSurface,
                    LotArea = house.Value.LotArea,
                    BuildYear = house.Value.BuildYear,
                    BasePostId = house.Value.BasePostId,
                    HouseTypeId = house.Value.HouseTypeId
                }
            };
        }
    }
}
