using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Aggregates.User.Comment;
using Lumen.Users.Domain.Aggregates.User.CommentImage;
using Lumen.Users.Domain.Aggregates.User.Community;
using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Aggregates.User.PostImage;
using Lumen.Users.Domain.Aggregates.User.RootAnswerComment;
using Lumen.Users.Domain.Aggregates.User.UserBoard;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Users.Infrastructure.Common;

public sealed class LumenDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<UserBoardEntity> UserBoards { get; set; }
    public DbSet<CommunityEntity> Communities { get; set; }
    public DbSet<RootCommentEntity> Comments { get; set; }
    public DbSet<RootAnswerCommentEntity> RootAnswerComments { get; set; }
    public DbSet<PostImageEntity> PostImages { get; set; }
    public DbSet<CommentImageEntity> CommentImages { get; set; }

    public LumenDbContext(DbContextOptions<LumenDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
