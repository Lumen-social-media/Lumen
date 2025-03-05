namespace Lumen.Users.Application.Aggregates.Users.Entities.Posts;

public sealed record PostResponse
{
    public int Id { get; set; }
    public required string Body { get; set; }

}
