using Newtonsoft.Json;
using RealEstate.App.Contracts;
using RealEstate.App.Operations.Create.Models;
using RealEstate.App.Operations.Fetch.Response;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace RealEstate.App.Services
{
	public class CreateService : ICreateService
	{
		private readonly HttpClient httpClient;

		public CreateService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<string> CreateAddress(AddressViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Addresses", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();

				ApiAddressResponse responseModel = JsonConvert.DeserializeObject<ApiAddressResponse>(content);
				Console.WriteLine("Address create result: " + content+ " ID: "+responseModel.address.id);
				return responseModel.address.id;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
				
		}

		public async Task CreateApartment(ApartmentViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Apartments", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine("hotelPension : " + content);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public async Task CreateCommercial(CommercialViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Commercials", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine("hotelPension : " + content);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		Task ICreateService.CreateCommercialCategory()
		{
			throw new NotImplementedException();
		}

		Task ICreateService.CreateCommercialSpecific()
		{
			throw new NotImplementedException();
		}

		public async Task CreateHotelPension(HotelPensionViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/HotelPensions", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine("hotelPension : "+content);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public async Task CreateHouse(HouseViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Houses", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine("hotelPension : " + content);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		Task ICreateService.CreateHouseType()
		{
			throw new NotImplementedException();
		}

		public async Task CreateLot(LotViewModel model)
		{
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Lot", model);

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine("hotelPension : " + content);
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		Task ICreateService.CreateLotClassification()
		{
			throw new NotImplementedException();
		}

		Task ICreateService.CreatePartitioning()
		{
			throw new NotImplementedException();
		}
	}
}
