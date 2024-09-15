using System.Collections.Generic;

namespace AiNotes.ViewModels;

public class NoteViewModel : ViewModelBase
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public List<string> Attachments { get; set; } = new();
}
