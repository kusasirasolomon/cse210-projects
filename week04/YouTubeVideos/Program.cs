using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");

        foreach (Comment comment in Comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create video list
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Jollof Rice", "Mama Africa", 420);
        video1.AddComment(new Comment("Kofi", "Looks delicious!"));
        video1.AddComment(new Comment("Ama", "My favorite recipe."));
        video1.AddComment(new Comment("James", "I tried it—amazing!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Learn C# in 15 Minutes", "Code Master", 900);
        video2.AddComment(new Comment("Lily", "This was super helpful."));
        video2.AddComment(new Comment("Jake", "Clear and concise."));
        video2.AddComment(new Comment("Anna", "Great intro to C#!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Tourist Spots in Uganda", "Travel Vibes", 600);
        video3.AddComment(new Comment("Solomon", "I’ve been to #3—amazing!"));
        video3.AddComment(new Comment("Grace", "Uganda is beautiful."));
        video3.AddComment(new Comment("Ben", "I’m adding this to my list."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("The Science of Sleep", "Brain Boost", 720);
        video4.AddComment(new Comment("Diana", "Now I understand REM sleep."));
        video4.AddComment(new Comment("Paul", "Very educational."));
        video4.AddComment(new Comment("Emily", "I'll sleep better tonight."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
