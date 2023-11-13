//using MediatR;
//using RealEstate.Application.Persistence;
//using RealEstate.Domain.Entities;

//namespace RealEstate.Application.Features.Categories.Commands.CreateApartament
//{
//    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, CreateApartmentCommandResponse>
//    {
//        private readonly IApartmentRepository repository;

//        public CreateApartmentCommandHandler(IApartmentRepository repository)
//        {
//            this.repository = repository;
//        }

//        public async Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
//        {
//            var response = new CreateApartmentCommandResponse();
//            var validator = new CreateApartmentCommandValidator();
//            var validationResult = await validator.ValidateAsync(request);

//            if (validationResult.Errors.Count > 0)
//            {
//                response.Success = false;
//                response.ValidationsErrors= new List<string>();
//                foreach (var error in validationResult.Errors)
//                {
//                    response.ValidationsErrors.Add(error.ErrorMessage);
//                }
//            }
//            if(response.Success)
//            {
//                var apartment = Apartment.Create(request.UserId, request.AddressId);

//            }
//            return response;
//        }
//    }
//}