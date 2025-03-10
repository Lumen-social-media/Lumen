using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Domain.Users;

namespace Lumen.Identity.Application.Users.Cache;

public interface IUserCache : IEntityCache<User, int>
{
}
