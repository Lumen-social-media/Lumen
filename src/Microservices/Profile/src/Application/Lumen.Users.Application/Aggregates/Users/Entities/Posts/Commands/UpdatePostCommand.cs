using Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Exceptions;
using Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Mappers.Extensions;
using Lumen.Profile.Application.Common;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.UseCases.Common;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Commands;

public sealed record UpdatePostCommand : ICommand<PostResponse>
{
    public required Guid Id { get; set; }
    public required JsonPatchDocument<Post> PatchDocument { get; set; }
}

public sealed class UpdatePostCommandHandler(IApplicationContext context) : ICommandHandler<UpdatePostCommand, PostResponse>
{
    public async Task<PostResponse> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var post = await context.Posts
            .Include(p => p.Owner)
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken)
                ?? throw new PostNotFoundException(command.Id);

        command.PatchDocument.ApplyTo(post);
        await context.SaveChangesAsync(cancellationToken);

        return post.ToResponse();
    }
} 