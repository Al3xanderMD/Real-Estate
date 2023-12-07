using RealEstate.Application.Models.Identity;

namespace RealEstate.Application.Contracts.Identity
{
	public interface IAuthService
	{
		Task<(int, string)> Registeration(RegistrationModel model, string role);
		Task<(int, string)> Login(LoginModel model);
	}
}
