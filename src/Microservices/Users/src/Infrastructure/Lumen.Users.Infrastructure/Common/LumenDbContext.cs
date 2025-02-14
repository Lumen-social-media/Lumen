using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Aggregates.User.Comment;
using Lumen.Users.Domain.Aggregates.User.Community;
using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Aggregates.User.UserBoard;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Users.Infrastructure.Common;

public sealed class LumenDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<UserBoard> UserBoards { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public LumenDbContext(DbContextOptions<LumenDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
