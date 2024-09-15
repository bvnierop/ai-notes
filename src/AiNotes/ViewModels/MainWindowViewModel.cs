using System.Collections.ObjectModel;
using System.Reactive;
using AiNotes.Models;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private NoteViewModel _selectedNote;
    public NoteViewModel SelectedNote
    {
        get => _selectedNote;
        set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
    }

    public ObservableCollection<NoteViewModel> Notes { get; set; }

    // Constructor
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<NoteViewModel>
        {
            new(new Note("Note 1", "Content for Note 1", [ new Attachment("Files/invoice2.png", AttachmentType.Image) ])),
            new(new Note("Note 2", "Content for Note 2", [])),
            new(new Note("Note 3", "Content for Note 3", []))
        };

        // Set a default selection (first note)
        if (Notes.Count > 0)
        {
            SelectedNote = Notes[0];
        }

        // Initialize commands
        AddAttachmentCommand = ReactiveCommand.Create(AddAttachment);
        RemoveAttachmentCommand = ReactiveCommand.Create<AttachmentViewModel>(RemoveAttachment);
    }

    private async void AddAttachment()
    {
        var filePath = "Files/invoice2.png";
        var type = AttachmentType.Image;
        SelectedNote.Attachments.Add(new AttachmentViewModel(new Attachment(filePath, type)));
    }

    private void RemoveAttachment(AttachmentViewModel attachment)
    {
        SelectedNote.Attachments.Remove(attachment);
    }

    // Commands
    public ReactiveCommand<Unit, Unit> AddAttachmentCommand { get; }
    public ReactiveCommand<AttachmentViewModel, Unit> RemoveAttachmentCommand { get; }
}
