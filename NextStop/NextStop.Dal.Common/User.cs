namespace NextStop.Dal.Common;

public class User(int? id, string? name, string? password, string? type)
{
    public int? Id { get; set; } = id;
    public string? Name { get; set; } = name;
    public string? Password { get; set; } = password;
    public string? Type { get; set; } = type;
}
