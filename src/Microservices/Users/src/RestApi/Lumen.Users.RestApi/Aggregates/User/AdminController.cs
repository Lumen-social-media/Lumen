using Lumen.Users.Application.Aggregates.User;
using Lumen.Users.Application.Aggregates.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates.User;

[ApiController]
[Route("/api/v1/admin")]
[Authorize]
public sealed class AdminController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpPost("/users")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateUser), response);
    }
}
