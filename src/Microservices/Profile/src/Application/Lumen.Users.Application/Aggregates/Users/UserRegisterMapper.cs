using Lumen.Profile.Domain.Aggregates.Users;
using Mapster;

namespace Lumen.Profile.Application.Aggregates.Users;

public sealed class UserRegisterMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResponse>()
            .RequireDestinationMemberSource(false);

    }
}
