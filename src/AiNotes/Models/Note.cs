namespace AiNotes.Models;

public class Note(string title, string body)
{
    public string Body { get; set; } = body;
    public string Title { get; set; } = title;
}
