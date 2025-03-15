using MediatR;

namespace Lumen.Profile.Application.Common;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
