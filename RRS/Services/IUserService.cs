namespace RRS.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
        string GetUserEmail();
    }
}