using RealEstate.App.Models;

namespace RealEstate.App.Contracts
{
    public interface IAuthentificationService
    {
        /*        Task<bool> AuthenticateAsync(string email, string password);
                // Task<bool> RegisterAsync(string username, string name, string email, string password, string phoneNumber);

                Task LogoutAsync(); // sa sterg token din browser*/

        Task Login(LoginViewModel loginRequest);
        Task Register(RegisterViewModel registerRequest);
        Task ForgotPassword(ForgotPasswordViewModel forgotPwRequest);
        Task ResetPassword(ResetPasswordViewModel resetPwRequest);
        Task Logout();
    }
}
