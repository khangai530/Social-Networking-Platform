using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBPosts;

public interface FB_IPostActions : FB_ILikeable
{
	void AddComment(FB_Comment comment);
	void SharePost(string userId);
	IReadOnlyList<FB_Comment> PostComments { get; }
	int ShareCount { get; }
}