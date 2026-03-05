using Facebook.Core.FBPosts;
using Facebook.Core.FBComments;

namespace Facebook.Core.FBUsers;

public interface FB_IUserActions
{
    FB_Post CreatePost(string postContent);
    FB_Post CreatePhotoPost(string postContent, string photoUrl);
    void LikePost(string postId);
    void CommentOnPost(string postId, string commentText);
}