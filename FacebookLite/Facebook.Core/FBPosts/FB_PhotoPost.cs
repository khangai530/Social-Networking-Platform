
using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBPosts;

public class FB_PhotoPost : FB_Post
{
    public FB_PhotoPost(FB_User postAuthor, string postContent, string photoUrl)
        : base(postAuthor, postContent)
    {
        PhotoUrl = photoUrl;
    }

    public string PhotoUrl { get; }

    public override string ToString()
    {
        return $"📷 {PostAuthor.UserName}: {PostContent} [Зураг: {PhotoUrl}] (Likes: {LikeCount})";
    }
}