using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AiNotes.Models;
using AiNotes.TextOverlay;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class NoteViewModel : ViewModelBase
{
    private Note _note;

    public NoteViewModel(Note note)
    {
        _note = note;
        Attachments = new ObservableCollection<AttachmentViewModel>(_note.Attachments.Select(a => new AttachmentViewModel(a)));
        Attachments.CollectionChanged += (sender, args) => {
            _note.Attachments = [..Attachments.Select(a => a.Attachment).ToArray()];
        };
    }

    public string Title
    {
        get => _note.Title;
        set {
            var t = _note.Title;
            this.RaiseAndSetIfChanged(ref t, value);
            _note.Title = t;
        }
    }

    public string Body
    {
        get => _note.Body;
        set {
            var t = _note.Body;
            this.RaiseAndSetIfChanged(ref t, value);
            _note.Body = t;
        }
    }

    public ObservableCollection<AttachmentViewModel> Attachments { get; set; }
}

public class AttachmentViewModel(Attachment attachment)
{
    public Attachment Attachment { get; } = attachment;
    private TextOverlayViewModel? _imageWithTextOverlay = null;

    public TextOverlayViewModel? ImageWithTextOverlay
    {
        get
        {
            if (_imageWithTextOverlay == null && Attachment.Type == AttachmentType.Image)
            {
                var image = new Bitmap(Attachment.FilePath);
                _imageWithTextOverlay = new TextOverlayViewModel
                {
                    Image = image,
                    TextRegions = new ObservableCollection<TextRegion>
                    {
                        new TextRegion { Text = "Foo", X = 0, Y = 0, Width = 210, Height = 50, },
                        new TextRegion { Text = "Bar", X = 0, Y = 250, Width = 50, Height = 25, }
                    }
                };
            }
            return _imageWithTextOverlay;
        }
    }

    public string FilePath => Attachment.FilePath;
    public AttachmentType Type => Attachment.Type;
}
