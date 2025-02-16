using MediatR;

namespace Lumen.Identity.Application.Common;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
