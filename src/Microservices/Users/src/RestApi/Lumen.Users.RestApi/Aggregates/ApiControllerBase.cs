using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Users.RestApi.Aggregates;

public abstract class ApiControllerBase(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator => mediator;
}
