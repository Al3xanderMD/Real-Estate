using Microsoft.AspNetCore.Components.Authorization;
using RealEstate.App.Contracts;
using RealEstate.App.Models;
using System.Security.Claims;

namespace RealEstate.App.Auth
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthentificationService authService;
        private readonly ITokenService tokenService;
        public CustomStateProvider(IAuthentificationService authService, ITokenService tokenService)
        {
            this.authService = authService;
            this.tokenService = tokenService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await tokenService.GetTokenAsync();
                if (userInfo != null)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, "user logged") };
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        /*public async Task Logout()
        {
            await authService.Logout();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }*/
        public async Task Login(LoginViewModel loginParameters)
        {
            await authService.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task Register(RegisterViewModel registerParameters)
        {
            await authService.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task ForgotPassword(ForgotPasswordViewModel forgotPwParameters)
        {
            await authService.ForgotPassword(forgotPwParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task ResetPassword(ResetPasswordViewModel resetPwParameters)
        {
            await authService.ResetPassword(resetPwParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
