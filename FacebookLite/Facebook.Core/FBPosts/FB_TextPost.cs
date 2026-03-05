using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBPosts;

public class FB_TextPost : FB_Post
{
    public FB_TextPost(FB_User postAuthor, string postContent)
        : base(postAuthor, postContent)
    { }

    public override string ToString()
    {
        return $"📝 {PostAuthor.UserName}: {PostContent} (Likes: {LikeCount}, Comments: {PostComments.Count})";
    }
}