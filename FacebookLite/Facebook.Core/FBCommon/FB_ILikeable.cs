using Facebook.Core.FBCommon;  // FB_Entity-д

namespace Facebook.Core.FBCommon;

public interface FB_ILikeable
{
    void AddLike(string userId);
    int LikeCount { get; }
}