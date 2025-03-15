using Lumen.Profile.Application.Common;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.UseCases.Common;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Commands;

public sealed record CreatePostCommand : ICommand<PostResponse>
{
    public required string Body { get; set; }
    public int OwnerId { get; set; }
    public int? CommunityId { get; set; }
}

public sealed class CreatePostCommandHandler(IApplicationContext context) : ICommandHandler<CreatePostCommand, PostResponse>
{
    public async Task<PostResponse> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var createdPost = await CreateAsync(command, cancellationToken);

        var response = new PostResponse { Body = createdPost.Body, Id = createdPost.Id };

        return response;
    }

    public async Task<Post> CreateAsync(CreatePostCommand command, CancellationToken cancellationToken)
    {
        return null;
    }
}
