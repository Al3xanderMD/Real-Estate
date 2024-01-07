using RealEstate.App.Contracts;
using RealEstate.App.Models;
using System.Net;
using System.Net.Http.Json;
using System.Web;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using System;

namespace RealEstate.App.Services
{
    public class AuthenticationService : IAuthentificationService
    {
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public AuthenticationService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task Login(LoginViewModel loginRequest)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/Authentication/login", loginRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync();
            await tokenService.SetTokenAsync(token);
        }



        public async Task Register(RegisterViewModel registerRequest)
        {
            var result = await httpClient.PostAsJsonAsync("api/v1/authentication/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            var content = await result.Content.ReadAsStringAsync();

			var json = JsonConvert.DeserializeObject<RegisterResponseModel>(content);
            
            ClientViewModel clientRequest = new ClientViewModel
            {
				userId = json.id,
				name = registerRequest.name,
                username = json.username,
				email = registerRequest.email,
				phoneNumber = registerRequest.phoneNumber
			};

            await CreateClient(clientRequest);

			Console.WriteLine("Register result: " + json.id);
            result.EnsureSuccessStatusCode();
        }

		public async Task CreateClient(ClientViewModel clientRequest)
		{
			var result = await httpClient.PostAsJsonAsync("api/v1/Client", clientRequest);
			if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
			{
				throw new Exception(await result.Content.ReadAsStringAsync());
			}
			var content = await result.Content.ReadAsStringAsync();

			Console.WriteLine("Client create result: " + content);
			result.EnsureSuccessStatusCode();
		}

		public async Task ForgotPassword(ForgotPasswordViewModel forgotPwRequest)
        {
            string link = "api/v1/authentication/forgotpassword?email=" + HttpUtility.UrlEncode(forgotPwRequest.Email);

            var result = await httpClient.PostAsync(link, null); ;
            
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();
        }

        public async Task ResetPassword(ResetPasswordViewModel resetPwRequest)
        {
            var result = await httpClient.PostAsJsonAsync("api/v1/authentication/resetpassword", resetPwRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();
        }
        

        public async Task Logout()
        {
			await tokenService.RemoveTokenAsync();
			//var result = await httpClient.PostAsync("api/v1/authentication/logout", null);
			//result.EnsureSuccessStatusCode();
		}

		public async Task FetchData(string id)
		{
			var result = await httpClient.GetAsync("api/v1/Client/" + id);
			if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
			{
				throw new Exception(await result.Content.ReadAsStringAsync());
			}
			var content = await result.Content.ReadAsStringAsync();

			Console.WriteLine("Client data result: " + content);
			result.EnsureSuccessStatusCode();
		}
	}
}
