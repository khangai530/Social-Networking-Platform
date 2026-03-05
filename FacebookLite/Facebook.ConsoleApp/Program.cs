using Facebook.Core.FBUsers;
using Facebook.Core.FBPosts;
using Facebook.Core.FBComments;
using Facebook.Core.FBRepos;
using Facebook.Core.FBServices;

namespace Facebook.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        FACEBOOK LITE v1.0            ║");
        Console.WriteLine("║      Өөрийн Facebook платформ        ║");
        Console.WriteLine("╚══════════════════════════════════════╝\n");

        //----------------------------------------------------------------
        // 1. Репозитори ба сервис үүсгэх
        //----------------------------------------------------------------
        var postRepo = new FB_MemoryRepo<FB_Post>();
        var postService = new FB_PostService(postRepo);

        //----------------------------------------------------------------
        // 2. Хэрэглэгчид үүсгэх
        //----------------------------------------------------------------
        Console.WriteLine("\n👥 Хэрэглэгчид үүсгэж байна...");

        var bold = new FB_StoryUser("Bold", "bold@facebook.com", 25);
        var tuya = new FB_StoryUser("Tuya", "tuya@facebook.com", 24);
        var bat = new FB_StoryUser("Bat", "bat@facebook.com", 30);

        Console.WriteLine($"✅ {bold.UserName} (Нас: {bold.UserAge}) - ID: {bold.UserId.Substring(0, 8)}...");
        Console.WriteLine($"✅ {tuya.UserName} (Нас: {tuya.UserAge})");
        Console.WriteLine($"✅ {bat.UserName} (Нас: {bat.UserAge})");

        //----------------------------------------------------------------
        // 3. Пост үүсгэх
        //----------------------------------------------------------------
        Console.WriteLine("\n📝 Пост нэмж байна...");

        var post1 = postService.CreatePost(bold, "Сайн уу? Энэ миний Facebook дээрх анхны пост!");
        var post2 = postService.CreatePhotoPost(tuya, "Өнөөдөр гэр бүлээрээ зураг авхууллаа", "family_photo.jpg");
        var post3 = postService.CreatePost(bat, "Програмчлал сурах хамгийн сайхан арга - практик дээр турших!");

        //----------------------------------------------------------------
        // 4. Like дарах
        //----------------------------------------------------------------
        Console.WriteLine("\n❤️ Like дарж байна...");

        postService.LikePost(post1.Id, tuya.UserId);
        postService.LikePost(post1.Id, bat.UserId);
        postService.LikePost(post2.Id, bold.UserId);
        postService.LikePost(post2.Id, bat.UserId);
        postService.LikePost(post3.Id, bold.UserId);
        postService.LikePost(post3.Id, tuya.UserId);

        //----------------------------------------------------------------
        // 5. Коммент нэмэх
        //----------------------------------------------------------------
        Console.WriteLine("\n💬 Коммент нэмж байна...");

        var comment1 = new FB_Comment(tuya, "Тавтай морил Bold аа! Facebook-д тавтай морил! 👋");
        postService.AddComment(post1.Id, comment1);

        var comment2 = new FB_Comment(bold, "Баярлалаа Tuya! 🌞");
        postService.AddComment(post1.Id, comment2);

        var comment3 = new FB_Comment(bat, "Гоё зураг авчээ! 📸");
        postService.AddComment(post2.Id, comment3);

        var comment4 = new FB_Comment(tuya, "Bat аа, чиний зөв! 👨‍💻");
        postService.AddComment(post3.Id, comment4);

        //----------------------------------------------------------------
        // 6. Комментод like дарах
        //----------------------------------------------------------------
        Console.WriteLine("\n❤️ Комментод like дарж байна...");

        comment1.AddLike(bat.UserId);
        comment1.AddLike(bold.UserId);
        comment3.AddLike(tuya.UserId);
        comment3.AddLike(bold.UserId);

        //----------------------------------------------------------------
        // 7. Пост түгээх
        //----------------------------------------------------------------
        Console.WriteLine("\n🔄 Пост түгээж байна...");

        post1.SharePost(tuya.UserId);
        post1.SharePost(bat.UserId);
        post2.SharePost(bold.UserId);
        post3.SharePost(tuya.UserId);

        //----------------------------------------------------------------
        // 8. Бүх постыг харуулах
        //----------------------------------------------------------------
        postService.ShowAllPosts();

        //----------------------------------------------------------------
        // 9. Facebook Story тест
        //----------------------------------------------------------------
        Console.WriteLine("\n=== 📱 FACEBOOK STORY ТЕСТ ===");

        var storyUser = new FB_StoryUser("Saraa", "saraa@facebook.com", 22);
        var story1 = storyUser.AddStory("Өнөөдрийн мөч... #facebookstory");
        var story2 = storyUser.AddStory("Хөгжилтэй байна 🤪");

        Console.WriteLine(story1);
        Console.WriteLine(story2);

        var activeStories = storyUser.GetActiveStories();
        Console.WriteLine($"Идэвхтэй story-нуудын тоо: {activeStories.Count}");

        //----------------------------------------------------------------
        // 10. Статистик
        //----------------------------------------------------------------
        Console.WriteLine("\n=== 📊 СТАТИСТИК ===");
        Console.WriteLine($"Нийт пост: {postService.GetPostCount()}");
        Console.WriteLine($"Нийт хэрэглэгч: 4 (Bold, Tuya, Bat, Saraa)");
        Console.WriteLine($"Нийт коммент: 4");
        Console.WriteLine($"Нийт like: {comment1.LikeCount + comment3.LikeCount + post1.LikeCount + post2.LikeCount + post3.LikeCount}");

        //----------------------------------------------------------------
        // 11. Дүгнэлт
        //----------------------------------------------------------------
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║     FACEBOOK LITE АМЖИЛТТАЙ        ║");
        Console.WriteLine("║       АЖИЛЛАЖ ДУУСЛАА!              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine("\nEnter дарж гарна уу.");
        Console.ReadLine();
    }
}