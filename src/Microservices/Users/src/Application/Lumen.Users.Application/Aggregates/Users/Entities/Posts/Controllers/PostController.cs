using Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Commands;
using Lumen.Profile.Application.Common;
using Lumen.Profile.UseCases.Common;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PostController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public PostController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<PostResponse>> UpdatePost(Guid id, [FromBody] JsonPatchDocument<Post> patchDocument, CancellationToken cancellationToken)
    {
        var command = new UpdatePostCommand
        {
            Id = id,
            PatchDocument = patchDocument
        };

        var response = await _commandDispatcher.Dispatch(command, cancellationToken);
        return Ok(response);
    }
} 