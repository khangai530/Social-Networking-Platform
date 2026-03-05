using Facebook.Core.FBCommon;

namespace Facebook.Core.FBUsers;

public abstract class FB_User : FB_Entity
{
    private readonly byte _userAge;

    // КОНСТРУКТОР - ЗӨВХӨН 1 БАЙХ ЁСТОЙ
    protected FB_User(string userName, string userEmail, byte userAge)
    {
        UserName = userName;
        UserEmail = userEmail;
        _userAge = userAge;
    }

    public string UserName { get; }
    public string UserEmail { get; }
    public byte UserAge => _userAge;
    public string UserId => Id;
    public bool IsActive { get; set; } = true;
}