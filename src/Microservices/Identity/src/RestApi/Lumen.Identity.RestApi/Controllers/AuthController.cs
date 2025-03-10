using Lumen.Identity.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Lumen.Identity.RestApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(AccessTokenResponse))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccessTokenResponse))]
    public async Task<ActionResult<AccessTokenResponse>> Register([FromBody] RegisterUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Register), response);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccessTokenResponse))]
    public async Task<ActionResult<AccessTokenResponse>> Login([FromBody] LoginUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccessTokenResponse))]
    public async Task<ActionResult<AccessTokenResponse>> RefreshToken(CancellationToken cancellationToken)
    {
        HttpContext.Request.Headers.TryGetValue("X-Refresh-token", out StringValues refreshToken);

        var accessToken = HttpContext.Request.Headers.Authorization.ToString();
        var token = refreshToken.ToString();
        var command = new RefreshUserTokenCommand { AccessToken = accessToken, RefreshToken = token };

        var response = await mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}
