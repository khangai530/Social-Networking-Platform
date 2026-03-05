using Facebook.Core.FBCommon;
using Facebook.Core.FBPosts;

namespace Facebook.Core.FBUsers;

public class FB_StoryUser : FB_User
{
    public FB_StoryUser(string userName, string userEmail, byte userAge)
        : base(userName, userEmail, userAge)
    { }

    // Хэрэглэгчийн story-нууд
    public List<FB_StoryPost> UserStories { get; } = new();

    // Шинэ story нэмэх
    public FB_StoryPost AddStory(string storyContent)
    {
        var story = new FB_StoryPost(this, storyContent);
        UserStories.Add(story);
        return story;
    }

    // ЗӨВХӨН ИДЭВХТЭЙ (ДУУСААГҮЙ) STORY-НУУД
    public List<FB_StoryPost> GetActiveStories()
    {
        // Хаана нь дуусаагүй байгаа story-нууд
        return UserStories.Where(s => !s.IsExpired).ToList();
    }

    // Story-нуудын тоо
    public int StoryCount => UserStories.Count;

    // Идэвхтэй story-нуудын тоо
    public int ActiveStoryCount => UserStories.Count(s => !s.IsExpired);
}