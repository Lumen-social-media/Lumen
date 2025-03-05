using Lumen.Users.Domain.Aggregates.Communities;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<Community> CreatedCommunities => createdCommunities;
    private List<Community> createdCommunities = new List<Community>();

    public void AddCommunity(string avatarUrl = "", string description = "")
    {
        var community = Community.Create(Id, avatarUrl, description);
        createdCommunities.Add(community);
    }

    public void RemoveCommunity(Community community)
    {
        createdCommunities.Remove(community);
    }
}
