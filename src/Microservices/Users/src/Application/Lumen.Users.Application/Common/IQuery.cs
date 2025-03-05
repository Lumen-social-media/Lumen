using MediatR;

namespace Lumen.Users.Application.Common;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
