using Lumen.Users.Domain.Aggregates.Communities;
using Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Users.UseCases;

public interface IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<RootComment> Comments { get; set; }
    public DbSet<RootAnswerComment> RootAnswerComments { get; set; }
    public DbSet<PostImage> PostImages { get; set; }
    public DbSet<CommentImage> CommentImages { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
