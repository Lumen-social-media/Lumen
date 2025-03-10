using Lumen.Identity.Domain.Users;
using Lumen.Identity.UseCase.Common;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Identity.Infrastructure.Common;

public sealed class LumenDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User> Users { get; set; }

    public LumenDbContext(DbContextOptions<LumenDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LumenDbContext).Assembly);
    }
}
