namespace KovanCaseStudy.Domain.Aggregates.UserAggregate;

public class User
{
    public User(string id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

    public string Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
}