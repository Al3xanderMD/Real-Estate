using System.Security.Claims;

namespace RealEstate.Application.Contracts.Interfaces
{
	public interface ICurrentUserService
	{
		string UserId { get; }
		ClaimsPrincipal GetCurrentClaimsPrincipal();
		string GetCurrentUserId();
	}
}
