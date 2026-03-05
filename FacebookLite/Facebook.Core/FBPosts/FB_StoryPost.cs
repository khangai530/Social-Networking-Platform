using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBPosts;

public class FB_StoryPost : FB_Post
{
    public FB_StoryPost(FB_User postAuthor, string postContent)
        : base(postAuthor, postContent)
    {
        ExpiresAt = CreatedAt.AddHours(24);
    }

    public DateTime ExpiresAt { get; }

    // ЭНЭ PROPERTY БАЙХ ЁСТОЙ
    public bool IsExpired => DateTime.UtcNow > ExpiresAt;

    public override string ToString()
    {
        string status = IsExpired ? "❌ Дууссан" : $"⏳ Дуусах: {ExpiresAt:HH:mm}";
        return $"📱 Story - {PostAuthor.UserName}: {PostContent} {status}";
    }
}