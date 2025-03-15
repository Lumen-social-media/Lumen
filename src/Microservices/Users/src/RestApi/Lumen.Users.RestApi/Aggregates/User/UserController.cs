using Lumen.Profile.Application.Aggregates.Users;
using Lumen.Profile.Application.Aggregates.Users.Commands;
using Lumen.Profile.Application.Aggregates.Users.Queries;
using Lumen.Profile.RestApi.Aggregates.User.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Profile.RestApi.Aggregates.User;

[ApiController]
[Route("api/v1/users")]
public sealed class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId:guid}/profile")]
    [ProducesResponseType(typeof(GetUserProfileQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetUserProfileQueryResponse>> GetProfile(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetUserProfileQuery { UserId = userId };
        var response = await mediator.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpPatch("{userId:guid}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<UserResponse>> Update(Guid userId, [FromBody] JsonPatchDocument<UpdateUserModel> model, CancellationToken cancellationToken)
    {
        var command = new UpdateUserCommand();
        var response = await mediator.Send(command, cancellationToken);
        
        return Ok(response);
    }

    [HttpDelete("{userId:guid}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<UserResponse>> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserByIdCommand { Id = userId };
        var response = await mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}