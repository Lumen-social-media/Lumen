using Lumen.Users.Application.Aggregates.User.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates.User;

[ApiController]
[Route("/api/v1/users")]
public class UserController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("/profile/{userId:int}")]
    [ProducesResponseType(typeof(GetUserProfileQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetUserProfileQueryResponse>> Profile(int userId, CancellationToken cancellationToken)
    {
        var query = new GetUserProfileQuery { UserId = userId };

        var response = await Mediator.Send(query, cancellationToken);

        return Ok(response);
    }

}