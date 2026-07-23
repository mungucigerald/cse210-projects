using System;

// Comment class to handle the comment features and display it.
public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public void DisplayCommentInfo()
    {
        Console.WriteLine($"Commenter: {_commenterName}");
        Console.WriteLine($"Comment: {_commentText}");
        Console.WriteLine();
    }
}
