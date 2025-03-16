using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Identity.UseCase.Users.Extensions;

public static class UserDbSetExtensions
{
    public static async Task<User?> FindByEmailAsync(this DbSet<User> dbSet, Email email, CancellationToken cancellationToken = default)
    {
        var user = await dbSet
            .Where(b => b.Email.Value == email.Value)
            .FirstOrDefaultAsync(cancellationToken);

        return user;
    }

    public static async Task<User?> FindByIdAsync(this DbSet<User> dbSet, Guid id, CancellationToken cancellationToken = default)
    {
        var user = await dbSet.FindAsync([id], cancellationToken);

        return user;
    }

    public static async Task<User?> DeleteByIdAsync(this DbSet<User> dbSet, Guid id, CancellationToken cancellationToken = default)
    {
        var user = await dbSet.FindByIdAsync(id, cancellationToken);

        if (user is null) return null;

        var entry = dbSet.Remove(user);

        return entry.Entity;
    }
}
