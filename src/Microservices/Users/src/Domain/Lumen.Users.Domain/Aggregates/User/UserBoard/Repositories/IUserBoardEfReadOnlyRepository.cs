using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.UserBoard.Repositories;

public interface IUserBoardEfReadOnlyRepository : IEfReadOnlyRepository<UserBoardEntity, int>
{
}
