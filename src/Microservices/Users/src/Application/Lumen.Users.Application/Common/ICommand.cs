using MediatR;

namespace Lumen.Users.Application.Common;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
