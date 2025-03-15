using MediatR;

namespace Lumen.Profile.Application.Common;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public new Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
