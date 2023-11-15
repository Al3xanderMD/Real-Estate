using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommandResponse : BaseResponse
    {
        public CreateAgentCommandResponse() : base()
        {
        }

        public CreateAgentDto Agent { get; set; }
    }
}
