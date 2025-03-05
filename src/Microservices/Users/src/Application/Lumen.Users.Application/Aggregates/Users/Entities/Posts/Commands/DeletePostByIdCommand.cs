using Lumen.Users.Application.Aggregates.Users.Entities.Posts.Exceptions;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.UseCases;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Users.Application.Aggregates.Users.Entities.Posts.Commands;

public sealed record DeletePostByIdCommand : ICommand<PostResponse>
{
    public required int Id { get; set; }
}

public sealed class DeletePostByIdCommandHandler(IApplicationContext context) : ICommandHandler<DeletePostByIdCommand, PostResponse>
{
    public async Task<PostResponse> Handle(DeletePostByIdCommand command, CancellationToken cancellationToken)
    {
        var post = await DeletePost(command, cancellationToken);

        var response = new PostResponse { Body = post.Body, Id = post.Id };

        return response;
    }

    public async Task<Post> DeletePost(DeletePostByIdCommand command, CancellationToken cancellationToken)
    {
        var post = await context.Posts
            .Include(p => p.Owner)
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken)
                ?? throw new PostNotFoundException(command.Id);

        post.Owner.RemovePost(post);
        await context.SaveChangesAsync(cancellationToken);

        return post;
    }
}
