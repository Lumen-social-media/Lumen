using MediatR;

namespace Lumen.Profile.Application.Common;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
