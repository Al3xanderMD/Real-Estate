using Microsoft.AspNetCore.Components.Authorization;
using RealEstate.App.Contracts;
using RealEstate.App.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
                var claims = new List<Claim>();

                if (userInfo != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(userInfo) as JwtSecurityToken;

                    if (jsonToken != null)
                    {
                        foreach (var claim in jsonToken.Claims)
                        {
                            if (claim.Type == "unique_name")
                            {
                                Console.WriteLine($"{claim.Type}: {claim.Value}");
                                claims.Add(new Claim(ClaimTypes.Name, claim.Value));
                            }
                            //Console.WriteLine($"{claim.Type}: {claim.Value}");
                            //claims.Add(new Claim(claim.Type, claim.Value));
                        }
                    }
                    else
                    {
                        Console.WriteLine("jsonToken is null");
                    }
                    //var claims = new[] { new Claim(ClaimTypes.Name, "user logged") };
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }


        public async Task Logout()
        {
            await authService.Logout();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
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
