using System.Collections.Generic;
using AiNotes.Models;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class NoteViewModel(Note note) : ViewModelBase
{
    private Note _note = note;

    // Title property with change notification
    public string Title
    {
        get => _note.Title;
        set {
            var t = _note.Title;
            this.RaiseAndSetIfChanged(ref t, value);
            _note.Title = t;
        }
    }

    // Body property with change notification
    public string Body
    {
        get => _note.Body;
        set {
            var t = _note.Body;
            this.RaiseAndSetIfChanged(ref t, value);
            _note.Body = t;
        }
    }
}
