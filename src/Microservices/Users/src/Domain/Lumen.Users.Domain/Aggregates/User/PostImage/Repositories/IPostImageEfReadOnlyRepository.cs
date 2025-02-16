using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.PostImage.Repositories;

public interface IPostImageEfReadOnlyRepository : IEfReadOnlyRepository<PostImageEntity, int>
{
}
