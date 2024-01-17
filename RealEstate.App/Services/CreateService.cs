using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using RealEstate.App.Contracts;
using RealEstate.App.Operations.Common;
using RealEstate.App.Operations.Create.Models;
using RealEstate.App.Operations.Fetch.Models;
using RealEstate.App.Operations.Fetch.Response;
using RealEstate.App.Operations.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace RealEstate.App.Services
{
	public class CreateService : ICreateService
	{
		private readonly HttpClient httpClient;
		private readonly ISnackbar snackBar;

		public CreateService(HttpClient httpClient, ISnackbar snackbar)
		{
			this.httpClient = httpClient;
			this.snackBar = snackbar;
		}

		public async Task<string> CreateAddress(AddressViewModel model)
		{
			CommercialResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Addresses", model);

				var content = await response.Content.ReadAsStringAsync();

				ApiAddressResponse responseModel = JsonConvert.DeserializeObject<ApiAddressResponse>(content);
				Console.WriteLine("Address create result: " + content+ " ID: "+responseModel.address.id);

				response_obj = JsonConvert.DeserializeObject<CommercialResponseModel>(content);


				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}
				} 

				response.EnsureSuccessStatusCode();


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
			ApartmentResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Apartments", model);

				var content = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<ApartmentResponseModel>(content);

				Console.WriteLine("apartment : " + content);	
				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

				
					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}
				}
				else
				{
					var url = "https://localhost:7190/api/v1/Post";

					Console.WriteLine("creating post with : " + response_obj.apartment.basePostId);

					var post = new PostCreateViewModel
					{
						basePostId = response_obj.apartment.basePostId,
						type = "apartment"
					};

					var result = await httpClient.PostAsJsonAsync(url, post);

					result.EnsureSuccessStatusCode();
				}

				response.EnsureSuccessStatusCode();
				Console.WriteLine("Apartment Success!!");
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public async Task CreateCommercial(CommercialViewModel model)
		{


			CommercialResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Commercials", model);

				var content = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<CommercialResponseModel>(content);

				Console.WriteLine("commercial : " + content);


				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

					// Now you can iterate through validationErrors or perform other actions
					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}

				}
				else {
					var url = "https://localhost:7190/api/v1/Post";

					Console.WriteLine("creating post with : " + response_obj.commercial.basePostId);

					var post = new PostCreateViewModel
					{
						basePostId = response_obj.commercial.basePostId,
						type = "commercial"
					};

					var result = await httpClient.PostAsJsonAsync(url, post);

					result.EnsureSuccessStatusCode();
				}

				response.EnsureSuccessStatusCode();

				
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
			HotelPensionResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/HotelPensions", model);

				var content = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<HotelPensionResponseModel>(content);

				Console.WriteLine("hotel : " + content);


				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}
				}
				else
				{
					var url = "https://localhost:7190/api/v1/Post";

					Console.WriteLine("creating post with : " + response_obj.hotelPension.basePostId);

					var post = new PostCreateViewModel
					{
						basePostId = response_obj.hotelPension.basePostId,
						type = "hotel"
					};

					var result = await httpClient.PostAsJsonAsync(url, post);

					result.EnsureSuccessStatusCode();
				}

				response.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public async Task CreateHouse(HouseViewModel model)
		{
			HouseResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Houses", model);

				var content = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<HouseResponseModel>(content);

				Console.WriteLine("house : " + content);


				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

					// Now you can iterate through validationErrors or perform other actions
					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}
				}
				else
				{
					var url = "https://localhost:7190/api/v1/Post";

					Console.WriteLine("creating post with : " + response_obj.house.basePostId);

					var post = new PostCreateViewModel
					{
						basePostId = response_obj.house.basePostId,
						type = "house"
					};

					var result = await httpClient.PostAsJsonAsync(url, post);

					result.EnsureSuccessStatusCode();
				}

				response.EnsureSuccessStatusCode();
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
			LotResponseModel response_obj;
			try
			{
				var response = await httpClient.PostAsJsonAsync("https://localhost:7190/api/v1/Lot", model);

				var content = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<LotResponseModel>(content);

				Console.WriteLine("lot : " + content);


				if (response_obj != null && !response_obj.Success)
				{
					List<string> validationErrors = response_obj.ValidationErrors;

					// Now you can iterate through validationErrors or perform other actions
					foreach (string error in validationErrors)
					{
						Console.WriteLine($"Validation Error: {error}");
						snackBar.Add($"{error}", Severity.Error);
					}
				}
				else
				{
					var url = "https://localhost:7190/api/v1/Post";

					Console.WriteLine("creating post with : " + response_obj.lot.basePostId);

					var post = new PostCreateViewModel
					{
						basePostId = response_obj.lot.basePostId,
						type = "lot"
					};

					var result = await httpClient.PostAsJsonAsync(url, post);

					result.EnsureSuccessStatusCode();
				}

				response.EnsureSuccessStatusCode();

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
