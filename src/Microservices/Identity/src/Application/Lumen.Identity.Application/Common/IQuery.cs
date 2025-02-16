using MediatR;

namespace Lumen.Identity.Application.Common;

public interface IQuery<TResponse> : IRequest<TResponse>;
