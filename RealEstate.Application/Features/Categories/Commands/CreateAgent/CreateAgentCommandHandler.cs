//using MediatR;
//using RealEstate.Application.Features.Categories.Commands.CreateAddress;
//using RealEstate.Application.Persistence;
//using RealEstate.Domain.Entities;

//namespace RealEstate.Application.Features.Categories.Commands.CreateAgent
//{
//    public class CreateAgentCommandHandler : IRequestHandler<CreateAddressCommand, CreateAgentCommandResponse>
//    {
//        private readonly IAgentRepository repository;

//        public CreateAgentCommandHandler(IAgentRepository repository)
//        {
//            this.repository = repository;
//        }

//        public async Task<CreateAgentCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
//        {
//            var response = new CreateAgentCommandResponse();
//            var validator = new CreateAgentCommandValidator();
//            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

//            if (validatorResult.Errors.Count > 0)
//            {
//                response.Success = false;
//                response.ValidationsErrors = new List<string>();
//                foreach (var error in validatorResult.Errors)
//                {
//                    response.ValidationsErrors.Add(error.ErrorMessage);
//                }
//            }
//            if (response.Success)
//            {
//                var agent = Agent.Create(request.UserId, request.AddressId, request.AgentName,request.Phone);
//                if (agent.IsSuccess)
//                {
//                    await repository.AddAsync(agent.Value);
//                    response.Agent = new CreateAgentDto
//                    {
//                        AgentName = agent.Value.AgentName,
//                        Logolink = agent.Value.Logolink,
//                        Phone = agent.Value.Phone,
//                        AddressId = agent.Value.AddressId,
//                        Url = agent.Value.Url,
//                        UserId = agent.Value.UserId
//                    };
//                }
//                else
//                {
//                    response.Success = false;
//                    response.ValidationsErrors = new List<string>()
//                    {
//                        agent.Error
//                    };
//                }
//            }
//            return response;
//        }
//    }
//}
