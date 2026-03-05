using Facebook.Core.FBPosts;
using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBRepos;

namespace Facebook.Core.FBServices;

public class FB_PostService
{
    private readonly FB_MemoryRepo<FB_Post> _postRepo;

    public FB_PostService(FB_MemoryRepo<FB_Post> postRepo)
    {
        _postRepo = postRepo;
    }

    public FB_Post CreatePost(FB_User author, string content)
    {
        var post = new FB_TextPost(author, content);
        _postRepo.Add(post);
        Console.WriteLine($"✅ Шинэ пост нэмэгдлээ: {author.UserName}");
        return post;
    }

    public FB_Post CreatePhotoPost(FB_User author, string content, string photoUrl)
    {
        var post = new FB_PhotoPost(author, content, photoUrl);
        _postRepo.Add(post);
        Console.WriteLine($"✅ Шинэ зурагтай пост нэмэгдлээ: {author.UserName}");
        return post;
    }

    public void LikePost(string postId, string userId)
    {
        var post = _postRepo.GetById(postId);
        post?.AddLike(userId);
    }

    public void AddComment(string postId, FB_Comment comment)
    {
        var post = _postRepo.GetById(postId);
        post?.AddComment(comment);
    }

    public void ShowAllPosts()
    {
        Console.WriteLine("\n=== 📱 FACEBOOK ПОСТУУД ===");
        var posts = _postRepo.GetAll();

        if (posts.Count == 0)
        {
            Console.WriteLine("Пост байхгүй байна.");
            return;
        }

        foreach (var post in posts)
        {
            Console.WriteLine(post);

            if (post.PostComments.Any())
            {
                Console.WriteLine("  💬 Комментууд:");
                foreach (var comment in post.PostComments)
                {
                    Console.WriteLine($"    - {comment.CommentAuthor.UserName}: {comment.CommentText} (Likes: {comment.LikeCount})");
                }
            }
            Console.WriteLine();
        }
    }

    public int GetPostCount() => _postRepo.Count;
}