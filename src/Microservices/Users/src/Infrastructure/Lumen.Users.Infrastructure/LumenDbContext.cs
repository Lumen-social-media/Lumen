using Microsoft.EntityFrameworkCore;
using Lumen.Users.Domain.Aggregates.Communities;
using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.UseCases;

namespace Lumen.Users.Infrastructure;

public sealed class LumenDbContext : DbContext, IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<RootComment> Comments { get; set; }
    public DbSet<RootAnswerComment> RootAnswerComments { get; set; }
    public DbSet<PostImage> PostImages { get; set; }
    public DbSet<CommentImage> CommentImages { get; set; }

    public LumenDbContext(DbContextOptions<LumenDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LumenDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
