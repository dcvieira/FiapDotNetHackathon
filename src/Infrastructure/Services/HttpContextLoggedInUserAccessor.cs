using Application.User;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;


namespace Infrastructure.Services;

public class HttpContextLoggedInUserAccessor : ILoggedInUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextLoggedInUserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public LoggedInUser? LoggedInUser => LoggedInUserFactory.CreateFromHttpContext(_httpContextAccessor.HttpContext!);
}

public class LoggedInUserFactory
{

    public static LoggedInUser? CreateFromHttpContext(HttpContext httpContext)
    {
        if (httpContext?.User?.Identity != null && httpContext.User.Identity.IsAuthenticated)
        {
            var email = httpContext.User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var identifires = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var userId = Guid.Parse(identifires);

            return new LoggedInUser(userId, email);
        }

        return null;

    }
}