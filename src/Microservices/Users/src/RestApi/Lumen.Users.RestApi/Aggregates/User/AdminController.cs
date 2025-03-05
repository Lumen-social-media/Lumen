using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates.User;

[ApiController]
[Route("/api/v1/admin")]
[Authorize]
public sealed class AdminController(IMediator mediator) : ApiControllerBase(mediator)
{
}
