using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.PostImage.Repositories;

public interface IPostImageEfWriteOnlyRepository : IEfWriteOnlyRepository<PostImageEntity, int> 
{
}
