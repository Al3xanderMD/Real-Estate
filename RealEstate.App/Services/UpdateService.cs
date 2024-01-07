using RealEstate.App.Contracts;
using RealEstate.App.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;


namespace RealEstate.App.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly HttpClient httpClient;

        public UpdateService(HttpClient httpClient)
        {
			this.httpClient = httpClient;
		}

        public async Task UpdateClientData(ClientDataViewModel clientRequest)
        {
            ClientUpdateModel clientUpdateModel = new ClientUpdateModel
            {
				userId = clientRequest.userId,
				name = clientRequest.name,
				phoneNumber = clientRequest.phoneNumber,
				imageUrl = "notimplyet"
			};
            var url = "https://localhost:7190/api/v1/Client/"+clientRequest.userId;
            Console.WriteLine("Client data request: " + clientRequest.userId +" "+clientRequest.name+" "+url);
            var result = await httpClient.PutAsJsonAsync(url, clientUpdateModel);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
				Console.WriteLine("UpdateClientData failed");
				throw new Exception(await result.Content.ReadAsStringAsync());
            }
            var content = await result.Content.ReadAsStringAsync();

            Console.WriteLine("Client data result: " + content);
            result.EnsureSuccessStatusCode();
        }
    }
}
