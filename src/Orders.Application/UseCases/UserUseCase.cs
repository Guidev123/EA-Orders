using Orders.Application.Services.Interfaces;
using System.Security.Claims;

namespace Orders.Application.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        public string GetUserId(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new(nameof(principal));
            }

            var claim = principal.FindFirst("sub") ?? principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value ?? string.Empty;
        }
    }
}
