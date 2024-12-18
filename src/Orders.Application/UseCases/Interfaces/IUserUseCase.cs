using System.Security.Claims;

namespace Orders.Application.Services.Interfaces
{
    public interface IUserUseCase
    {
        string GetUserId(ClaimsPrincipal principal);
    }
}
