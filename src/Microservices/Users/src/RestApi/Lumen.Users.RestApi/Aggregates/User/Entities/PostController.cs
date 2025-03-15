using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Profile.RestApi.Aggregates.User.Entities;

[ApiController]
[Route("api/posts")]
public sealed class PostController(IMediator mediator) : ApiControllerBase(mediator)
{
}
