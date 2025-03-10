using Lumen.Users.Application.Aggregates.Users;
using Lumen.Users.Application.Aggregates.Users.Commands;
using Lumen.Users.Application.Aggregates.Users.Queries;
using Lumen.Users.Domain.Aggregates.Users.Dtos;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Mapster;
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
        var command = userDto.Adapt<CreateUserCommand>();
        var response = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateUser), response);
    }

    [HttpGet("{userId:int}/profile")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserProfileQueryResponse))]
    public async Task<ActionResult<GetUserProfileQueryResponse>> GetProfile(int userId, CancellationToken cancellationToken)
    {
        var query = new GetUserProfileQuery { UserId = UserId.Create(userId) };
        var response = await Mediator.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    public async Task<ActionResult<UserResponse>> DeleteUser(int userId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserByIdCommand { Id = UserId.Create(userId) };
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

}