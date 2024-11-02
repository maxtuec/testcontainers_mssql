namespace NextStop.Dal.Common;

public class User(int? userId, string? name, string? password, string? type)
{
    public int? UserId { get; set; } = userId;
    public string? Name { get; set; } = name;
    public string? Password { get; set; } = password;
    public string? Type { get; set; } = type;
}
