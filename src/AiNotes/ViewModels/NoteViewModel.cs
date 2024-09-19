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
            _note.Title = value;
            this.RaisePropertyChanged();
        }
    }

    public string Body
    {
        get => _note.Body;
        set {
            _note.Body = value;
            this.RaisePropertyChanged();
        }
    }

    public ObservableCollection<AttachmentViewModel> Attachments { get; set; }
}
