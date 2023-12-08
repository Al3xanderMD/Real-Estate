using RealEstate.Application.Models.Identity;
using RealEstate.Identity.Models;

namespace RealEstate.Application.Contracts.Identity
{
	public interface IAuthService
	{
		Task<(int, string)> Registeration(RegistrationModel model, string role);
		Task<(int, string)> Login(LoginModel model);
		Task<(int, string)> ConfirmEmail(string email, string token);
		Task<(int, string)> ForgotPassword(string email);
	//	Task<(int, string)> ResetPassword(string email, string token);
		Task<(int, string)> ResetPasswordConfirmation(ResetPasswordModel model);
	}
}
