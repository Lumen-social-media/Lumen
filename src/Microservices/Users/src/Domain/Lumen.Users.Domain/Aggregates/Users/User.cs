using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Dtos;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;
using Mapster;
using System.Diagnostics.CodeAnalysis;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed partial class User : IAggregateRoot, IEntity<UserId>
{
    public UserId Id { get; set; }
    public string UserName { get; private set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;
    public string Hometown { get; set; } = string.Empty;
    public Language Language { get; set; } = Language.NotSet;
    public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.NotSet;
    public string SchoolName { get; set; } = string.Empty;
    public bool HasPublicProfile { get; set; }
    public bool OnlyRegisteredUsersCanViewProfile { get; set; }

    [SetsRequiredMembers]
    private User()
    {
    }

    public static User Create(CreateUserDto dto)
    {
        var config = new TypeAdapterConfig().NewConfig<CreateUserDto, User>()
            .RequireDestinationMemberSource(false)
            .Config;

        var user = dto.Adapt<User>(config);

        //var user = new User
        //{
        //    UserName = dto.UserName,
        //    Name = dto.Name,
        //    Surname = dto.Surname,
        //    Email = dto.Email,
        //    LastName = dto.LastName,
        //    About = dto.About,
        //    AvatarUrl = dto.AvatarUrl,
        //    BirthDate = dto.BirthDate,
        //    Hometown = dto.Hometown,
        //    Language = dto.Language,
        //    MaritalStatus = dto.MaritalStatus,
        //    CurrentCity = dto.CurrentCity,
        //    PersonalSite = dto.PersonalSite,
        //    Gender = dto.Gender,
        //    SchoolName = dto.SchoolName,
        //    HasPublicProfile = dto.HasPublicProfile,
        //    OnlyRegisteredUsersCanViewProfile = dto.OnlyRegisteredUsersCanViewProfile
        //};

        var validator = new UserValidator();
        validator.ValidateAndThrow(user);

        return user;
    }

    public User PartiallyUpdate(PartiallyUpdateUserDto dto)
    {
        var config = new TypeAdapterConfig().NewConfig<PartiallyUpdateUserDto, User>()
            .RequireDestinationMemberSource(false)
            .IgnoreNullValues(true)
            .Config;

        var user = dto.Adapt<User>(config);

        var validator = new UserValidator();
        validator.ValidateAndThrow(this);

        return user;
    }

    //private class Mapper
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="user"></param>
    //    /// <param name="dto"></param>
    //    /// <returns>Updated <paramref name="user"/></returns>
    //    public static User MapIgnoringNull(User user, PartiallyUpdateUserDto dto)
    //    {
    //        if (!string.IsNullOrWhiteSpace(dto.UserName))
    //            user.UserName = dto.UserName;

    //        if (!string.IsNullOrWhiteSpace(dto.Name))
    //            user.Name = dto.Name;

    //        if (!string.IsNullOrWhiteSpace(dto.Surname))
    //            user.Surname = dto.Surname;

    //        if (!string.IsNullOrWhiteSpace(dto.LastName))
    //            user.LastName = dto.LastName;

    //        if (!string.IsNullOrWhiteSpace(dto.About))
    //            user.About = dto.About;

    //        if (dto.BirthDate.HasValue)
    //            user.BirthDate = dto.BirthDate;

    //        if (!string.IsNullOrWhiteSpace(dto.Hometown))
    //            user.Hometown = dto.Hometown;

    //        if (dto.Language.HasValue)
    //            user.Language = dto.Language.Value;

    //        if (dto.MaritalStatus.HasValue)
    //            user.MaritalStatus = dto.MaritalStatus.Value;

    //        if (!string.IsNullOrWhiteSpace(dto.CurrentCity))
    //            user.CurrentCity = dto.CurrentCity;

    //        if (!string.IsNullOrWhiteSpace(dto.PersonalSite))
    //            user.PersonalSite = dto.PersonalSite;

    //        if (dto.Gender.HasValue)
    //            user.Gender = dto.Gender.Value;

    //        if (!string.IsNullOrWhiteSpace(dto.SchoolName))
    //            user.SchoolName = dto.SchoolName;

    //        if (dto.HasPublicProfile.HasValue)
    //            user.HasPublicProfile = dto.HasPublicProfile.Value;

    //        if (dto.OnlyRegisteredUsersCanViewProfile.HasValue)
    //            user.OnlyRegisteredUsersCanViewProfile = dto.OnlyRegisteredUsersCanViewProfile.Value;

    //        return user;
    //    }
    //}
}
