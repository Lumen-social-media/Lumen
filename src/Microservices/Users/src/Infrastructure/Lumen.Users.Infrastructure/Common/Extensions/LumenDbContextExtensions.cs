namespace Lumen.Users.Infrastructure.Common.Extensions;

public static class LumenDbContextExtensions
{

    public static async Task<int> SaveChangesAsync(this LumenDbContext dbContext, CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

}
