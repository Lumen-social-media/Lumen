using MediatR;

namespace Lumen.Users.Application.Common;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public new abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
