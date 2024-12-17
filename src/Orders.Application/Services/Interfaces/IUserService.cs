namespace Orders.Application.Services.Interfaces
{
    public interface IUserService
    {
        Guid GetUserId();
        bool IsAuthenticated();
    }
}
