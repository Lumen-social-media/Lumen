using MediatR;

namespace Lumen.Profile.Application.Common;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    public new Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
