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
            .FirstOrDefaultAsync();

        return user;
    }

    public static async Task<User?> FindByIdAsync(this DbSet<User> dbSet, int id, CancellationToken cancellationToken = default)
    {
        var user = await dbSet.FindAsync([id], cancellationToken);

        return user;
    }
}
