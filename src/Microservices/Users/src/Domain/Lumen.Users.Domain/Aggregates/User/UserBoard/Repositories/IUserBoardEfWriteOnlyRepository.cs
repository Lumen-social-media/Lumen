using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.UserBoard.Repositories;

public interface IUserBoardEfWriteOnlyRepository : IEfWriteOnlyRepository<UserBoardEntity, int>
{
}
