using Lumen.Users.Application.Aggregates.Users;
using Lumen.Users.Application.Aggregates.Users.Commands;
using Lumen.Users.Domain.Aggregates.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates.User;

[ApiController]
[Route("/api/v1/users")]
public class UserController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponse))]
    public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserDto userDto, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand { Dto = userDto };
        var response = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateUser), response);
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    public async Task<ActionResult<UserResponse>> DeleteUser(int userId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserByIdCommand { Id = userId };
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

}