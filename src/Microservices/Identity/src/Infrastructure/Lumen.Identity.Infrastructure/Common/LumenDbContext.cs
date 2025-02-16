using Lumen.Identity.Infrastructure.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lumen.Identity.Infrastructure.Common;

public sealed class LumenDbContext : IdentityDbContext<InfrastructureUser, IdentityRole<int>, int>
{
}
