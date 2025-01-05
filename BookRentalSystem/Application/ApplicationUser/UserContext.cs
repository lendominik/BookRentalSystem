using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.ApplicationUser;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;

        if (user is null)
        {
            throw new InvalidOperationException("Context user is not present");
        }

        var id = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;

        return new CurrentUser(id, email);
    }
}