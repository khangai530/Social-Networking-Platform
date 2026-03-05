using Facebook.Core.FBCommon;  // FB_Entity-д

namespace Facebook.Core.FBCommon;

public abstract class FB_Entity
{
    protected FB_Entity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
    }

    public string Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; protected set; }
}