using Lumen.Users.Application.Aggregates.Users.Entities.Posts;
using Lumen.Users.Application.Aggregates.Users.Entities.Posts.Commands;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates.User.Entities;

[ApiController]
[Route("api/posts")]
public sealed class PostController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpPost("{ownerId:int}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostResponse>> CreatePost(int ownerId, [FromBody] CreatePostDto dto, [FromQuery] int? communityId, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand { Dto = dto };
        var response = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreatePost), response);
    }
}
