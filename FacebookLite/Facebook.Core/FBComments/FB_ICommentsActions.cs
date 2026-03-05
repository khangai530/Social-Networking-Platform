using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBComments;

public interface FB_ICommentActions : FB_ILikeable
{
    FB_User CommentAuthor { get; }
    string CommentText { get; }
}