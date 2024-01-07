using RealEstate.App.Contracts;
using RealEstate.App.Models;

namespace RealEstate.App.Operations.Update
{
    public class UpdateProvider
    {
        private readonly IUpdateService updateService;

        public async Task UpdateClientData(ClientDataViewModel clientRequest)
        {
            await updateService.UpdateClientData(clientRequest);
        }
    }
}
