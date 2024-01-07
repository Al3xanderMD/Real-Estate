using RealEstate.App.Models;

namespace RealEstate.App.Contracts
{
    public interface IUpdateService
    {
        Task UpdateClientData(ClientDataViewModel clientRequest);
    }
}
