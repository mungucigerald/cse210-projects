using System;
class Program
{
    static void Main(string[] args)
    {
        // Initiate a list to store videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment(new Comment("User 1", "Great video!"));
        video1.AddComment(new Comment("User 2", "I learned a lot!"));
        video1.AddComment(new Comment("User 3", "Thanks for sharing!"));
        videos.Add(video1);

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment(new Comment("User 4", "Excellent content!"));
        video2.AddComment(new Comment("User 5", "Very informative."));
        video2.AddComment(new Comment("User 6", "I appreciate the effort!"));
        video2.AddComment(new Comment("User 7", "This was really helpful!"));
        videos.Add(video2);

        Video video3 = new Video("Video 3", "Author 3", 240);
        video3.AddComment(new Comment("User 8", "Fantastic explanation!"));
        video3.AddComment(new Comment("User 9", "I will definitely apply this knowledge."));
        video3.AddComment(new Comment("User 10", "Keep up the good work!"));
        videos.Add(video3);

        Video video4 = new Video("Video 4", "Author 4", 300);
        video4.AddComment(new Comment("User 11", "This is a game-changer!"));
        video4.AddComment(new Comment("User 12", "I can't wait to try this out!"));
        video4.AddComment(new Comment("User 13", "Your content is always top-notch!"));
        video4.AddComment(new Comment("User 14", "I appreciate the clarity in your explanations."));
        videos.Add(video4);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}