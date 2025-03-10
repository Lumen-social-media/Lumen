using Lumen.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Identity.UseCase.Common;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
