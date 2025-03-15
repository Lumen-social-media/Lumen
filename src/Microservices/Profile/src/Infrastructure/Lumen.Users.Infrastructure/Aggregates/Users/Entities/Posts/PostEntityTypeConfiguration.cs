using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Entities.Posts;

public sealed class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.Posts)
            .HasForeignKey(b => b.OwnerId);

        builder.HasOne(b => b.Community)
            .WithMany(b => b.Posts)
            .HasForeignKey(b => b.CommunityId);

        builder.HasMany(b => b.Images)
            .WithOne(b => b.Post)
            .HasForeignKey(b => b.PostId);

        builder.HasMany(b => b.RootComments)
            .WithOne(b => b.Post)
            .HasForeignKey(b => b.PostId);
    }
} 