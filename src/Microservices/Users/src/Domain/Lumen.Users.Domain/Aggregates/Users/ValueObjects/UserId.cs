namespace Lumen.Users.Domain.Aggregates.Users.ValueObjects;

public sealed record UserId : ValueObject
{
    public int Value { get; set; }

    private UserId()
    {

    }

    public static UserId Create(int value)
    {
        var userId = new UserId { Value = value };

        return userId;
    }
}
