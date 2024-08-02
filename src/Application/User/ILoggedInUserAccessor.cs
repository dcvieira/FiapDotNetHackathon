

namespace Application.User;

public interface ILoggedInUserAccessor
{
    public LoggedInUser? LoggedInUser { get; }
}

public class LoggedInUser
{
    public LoggedInUser(Guid userId,  string email)
    {
        UserId = userId;
        Email = email;
    }

    public Guid UserId { get; set; }
    public string Email { get; set; }
}