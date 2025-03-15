using Lumen.Profile.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Entities.RootAnswerComments;

public sealed class RootAnswerCommentEntityTypeConfiguration : IEntityTypeConfiguration<RootAnswerComment>
{
    public void Configure(EntityTypeBuilder<RootAnswerComment> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.RootAnswerComments)
            .HasForeignKey(b => b.OwnerId);

        builder.HasOne(b => b.Root)
            .WithMany(b => b.Answers)
            .HasForeignKey(b => b.RootId);
    }
} 