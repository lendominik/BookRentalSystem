namespace Application.ApplicationUser;

public interface IUserContext
{
    CurrentUser GetCurrentUser();
}