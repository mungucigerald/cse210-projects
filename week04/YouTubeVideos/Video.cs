using System;
using System.Collections.Generic;

// This class represents a YouTube video with its title, author, length, and associated comments. 
// It provides methods to add comments and display video information along with the comments.
public class Video
{
    // Private fields to store the title, author, length in seconds, and a list of comments for the video.
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    private int _commentsCount;

    // Constructor to initialize a new instance of the Video class with the specified title, author, and length in seconds.
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment to the video. It takes a Comment object as a parameter and adds it to the list of comments.
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Count the comments in the list and return value
    public int GetCommentCount
    {
        get { return _comments.Count; }
    }
    // Method to display the video information, including title, author, length, number of comments, and the details of each comment.
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount}");
        Console.WriteLine("Comments:");
        // Iterate through the list of comments and call the DisplayCommentInfo method for each comment to display its details.
        foreach (var comment in _comments)
        {
            comment.DisplayCommentInfo();
        }
    }
}
