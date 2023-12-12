using RealEstate.App.Contracts;
using RealEstate.App.Models;
using System.Net.Http.Json;
namespace RealEstate.App.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public AuthentificationService(HttpClient httpClient, ITokenService tokenService)
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

        /*       public async Task Logout()
               {
                   await tokenService.RemoveTokenAsync();
                   var result = await httpClient.PostAsync("api/v1/authentication/logout", null);
                   result.EnsureSuccessStatusCode();
               }

               public async Task Register(RegisterViewModel registerRequest)
               {
                   var result = await httpClient.PostAsJsonAsync("api/v1/authentication/register", registerRequest);
                   if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                   {
                       throw new Exception(await result.Content.ReadAsStringAsync());
                   }
                   result.EnsureSuccessStatusCode();
               }*/
    }
}
