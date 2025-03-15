using Lumen.Profile.Domain.Aggregates.Users;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Email;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Profile.UseCases.Aggregates.Users.Extensions;

public static class UserDbSetExtensions
{
    public static async Task<User?> FindByIdAsync(this DbSet<User> set, Guid id, CancellationToken cancellationToken = default)
    {
        return await set.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public static async Task<User?> FindByEmailAsyn(this DbSet<User> set, Email email, CancellationToken cancellationToken = default)
    {
        var user = await set
            .Where(u => u.Email.Value == email.Value)
            .FirstOrDefaultAsync(cancellationToken);

        return user;
    }

    public static async Task<User?> DeleteByIdAsync(this DbSet<User> set, Guid id, CancellationToken cancellationToken = default)
    {
        var user = await set.FindByIdAsync(id, cancellationToken);

        if (user is null) return null;
        ICommandDispatcher
        var e = set.Remove(user);
        e.CurrentValues.SetValues(,)
        return user;
    }
}
