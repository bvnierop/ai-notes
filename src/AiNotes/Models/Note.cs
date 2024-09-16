using System.Collections.Generic;

namespace AiNotes.Models;

public class Note(string title, string body, List<ImageAttachment> attachments)
{
    public string Body { get; set; } = body;
    public string Title { get; set; } = title;
    public List<ImageAttachment> Attachments { get; set; } = attachments;
}
