using Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Entities.CommentImages;

public sealed class CommentImageEntityTypeConfiguration : IEntityTypeConfiguration<CommentImage>
{
    public void Configure(EntityTypeBuilder<CommentImage> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.CommentImages)
            .HasForeignKey(b => b.OwnerId);

        builder.HasOne(b => b.Comment)
            .WithMany(b => b.Images)
            .HasForeignKey(b => b.CommentId);
    }
} 