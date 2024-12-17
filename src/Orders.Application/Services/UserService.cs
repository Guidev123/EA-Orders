using Microsoft.AspNetCore.Http;
using Orders.Application.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Orders.Application.UseCases
{
    public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public Guid GetUserId()
        {
            if (IsAuthenticated())
            {
                var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
                    return userId;
            }

            return Guid.Empty;
        }

        public bool IsAuthenticated() =>
            _httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated;
    }
}
