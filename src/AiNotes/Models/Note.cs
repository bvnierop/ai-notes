using System.Collections.Generic;

namespace AiNotes.Models;

public class Note(string title, string body, List<Attachment> attachments)
{
    public string Body { get; set; } = body;
    public string Title { get; set; } = title;
    public List<Attachment> Attachments { get; set; } = attachments;
}
