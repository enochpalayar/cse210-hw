public class Video
{
    public string _title;
    public string _author;
    public int _length;
    private List<Comment>_comments;

    public Video(string videoTitle, string videoAuthor, int videoLength)
    {
        _title = videoTitle;
        _author = videoAuthor;
        _length = videoLength;
        _comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment._name}: {comment._comment}");
        }
        Console.WriteLine();
    }
}