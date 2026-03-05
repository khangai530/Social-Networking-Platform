using Facebook.Core.FBCommon;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBComments;

public class FB_Comment : FB_Entity, FB_ILikeable
{
    private readonly List<string> _likedBy = new();

    public FB_Comment(FB_User commentAuthor, string commentText)
    {
        CommentAuthor = commentAuthor;
        CommentText = commentText;
    }

    public FB_User CommentAuthor { get; }
    public string CommentText { get; }

    public int LikeCount => _likedBy.Count;

    public void AddLike(string userId)
    {
        if (!_likedBy.Contains(userId))
        {
            _likedBy.Add(userId);
            Console.WriteLine($"❤️ {CommentAuthor.UserName}-ийн комментод like дарлаа");
        }
    }
}