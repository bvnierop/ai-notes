using ReactiveUI;

namespace AiNotes.Models;
public enum AttachmentType
{
    Image,
    Video,
    Audio,
    Other
}

public class Attachment : ReactiveObject
{
    private string _filePath;
    private AttachmentType _type;

    // File path for the attachment
    public string FilePath
    {
        get => _filePath;
        set => this.RaiseAndSetIfChanged(ref _filePath, value);
    }

    // Type of attachment (image, video, audio)
    public AttachmentType Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }

    // Constructor
    public Attachment(string filePath, AttachmentType type)
    {
        FilePath = filePath;
        Type = type;
    }
}
