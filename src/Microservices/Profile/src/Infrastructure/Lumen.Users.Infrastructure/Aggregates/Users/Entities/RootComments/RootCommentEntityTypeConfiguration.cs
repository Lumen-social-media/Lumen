using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Entities.RootComments;

public sealed class RootCommentEntityTypeConfiguration : IEntityTypeConfiguration<RootComment>
{
    public void Configure(EntityTypeBuilder<RootComment> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.RootComments)
            .HasForeignKey(b => b.OwnerId);

        builder.HasOne(b => b.Post)
            .WithMany(b => b.RootComments)
            .HasForeignKey(b => b.PostId);

        builder.HasMany(b => b.Images)
            .WithOne(b => b.Comment)
            .HasForeignKey(b => b.CommentId);

        builder.HasMany(b => b.Answers)
            .WithOne(b => b.Root)
            .HasForeignKey(b => b.RootId);
    }
} 