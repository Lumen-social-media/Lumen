using Lumen.Users.Domain.Aggregates.Users;
using Mapster;

namespace Lumen.Users.Application.Aggregates.Users;

public sealed class UserRegisterMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResponse>()
            .RequireDestinationMemberSource(false)
            .Map(u => u.Id, u => u.Id.Value);

    }
}
