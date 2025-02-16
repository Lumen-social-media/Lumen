using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Post.Repositories;

public interface IPostEfWriteOnlyRepository : IEfWriteOnlyRepository<PostEntity, int>
{ 
}
