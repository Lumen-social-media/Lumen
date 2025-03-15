using Lumen.Profile.Domain.Aggregates.Users.Entities.PostImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Entities.PostImages;

public sealed class PostImageEntityTypeConfiguration : IEntityTypeConfiguration<PostImage>
{
    public void Configure(EntityTypeBuilder<PostImage> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.PostImages)
            .HasForeignKey(b => b.OwnerId);

        builder.HasOne(b => b.Post)
            .WithMany(b => b.Images)
            .HasForeignKey(b => b.PostId);
    }
} 