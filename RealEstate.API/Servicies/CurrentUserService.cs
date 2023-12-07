using RealEstate.Application.Contracts.Interfaces;
using System.Security.Claims;
using Microsoft.Identity.Web;

namespace RealEstate.API.Servicies
{
	public class CurrentUserService : ICurrentUserService
	{
		private readonly IHttpContextAccessor httpContextAccessor;

		public CurrentUserService(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor; // aici am acces la token, de la asta dau drepuri
		}

		public string UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
		public ClaimsPrincipal GetCurrentClaimsPrincipal() // intoarte toate inf unui user
		{
			if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null)
			{
				return httpContextAccessor.HttpContext.User;
			}

			return null!;
		}

		public string GetCurrentUserId() // intoarce id-ul unui user
		{
			return GetCurrentClaimsPrincipal()?.GetObjectId()!;
		}
	}
}
