using Facebook.Core.FBCommon;
using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBPosts;

public abstract class FB_Post : FB_Entity, FB_IPostActions
{
    private readonly List<FB_Comment> _comments = new();
    private readonly List<string> _likedBy = new();

    protected FB_Post(FB_User postAuthor, string postContent)
    {
        PostAuthor = postAuthor;
        PostContent = postContent;
    }

    public FB_User PostAuthor { get; }
    public string PostContent { get; }

    // FB_ILikeable
    public int LikeCount => _likedBy.Count;
    public void AddLike(string userId)
    {
        if (!_likedBy.Contains(userId))
        {
            _likedBy.Add(userId);
            Console.WriteLine($"👍 {PostAuthor.UserName}-ийн постод like дарлаа");
        }
    }

    // FB_IPostActions
    public IReadOnlyList<FB_Comment> PostComments => _comments.AsReadOnly();

    public void AddComment(FB_Comment comment)
    {
        _comments.Add(comment);
        UpdatedAt = DateTime.UtcNow;
        Console.WriteLine($"💬 {comment.CommentAuthor.UserName} коммент үлдээв: {comment.CommentText}");
    }

    public int ShareCount { get; private set; }

    public void SharePost(string userId)
    {
        ShareCount++;
        Console.WriteLine($"🔄 {userId} постыг түгээв");
    }
}