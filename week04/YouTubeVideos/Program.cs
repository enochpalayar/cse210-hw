using System;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Why Software Development", "Enoch Palayar", 400);
        Video v2 = new Video("Basics of Accounting", "Alliah Mago", 800);
        Video v3 = new Video("Let's learn Animal Science", "Nelsam Palayar", 300);

        v1.AddComment(new Comment("Jared Cedron", "Nice explanation."));
        v1.AddComment(new Comment("Hazel Bayani", "This is an amazing video."));
        v1.AddComment(new Comment("Ether Lavadia", "Thank you for sharing this video"));

        v2.AddComment(new Comment("Aloha Mae", "It looks like I'm going to pursue accounting now."));
        v2.AddComment(new Comment("Pamela Balodong", "You're really good in accounting."));
        v2.AddComment(new Comment("Mary Angeline", "I want to know more about accounting."));

        v3.AddComment(new Comment("Dallin Gamil", "Let's do learn Animal Science."));
        v3.AddComment(new Comment("Crez Calingacion", "Thanks for this tutorial."));
        v3.AddComment(new Comment("Sixto Ramos", "It's so amazing to learn Animal Science."));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }

    }
}