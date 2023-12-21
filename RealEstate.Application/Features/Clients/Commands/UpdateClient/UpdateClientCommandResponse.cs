using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandResponse : BaseResponse
    {
        public UpdateClientCommandResponse() : base()
        {
        }

        public UpdateClientDto Client { get; set; }
    }
}
