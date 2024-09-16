using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AiNotes.Models;
using Avalonia.Media;
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
