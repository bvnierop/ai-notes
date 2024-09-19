using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using AiNotes.Models;
using AiNotes.Scripts;
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

     // Commands for the buttons
     public ICommand SummaryCommand { get; }
     public ICommand TasksCommand { get; }
     public ICommand AutoCompleteCommand { get; }

    // Constructor
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<NoteViewModel>
        {
            new(new Note("Note 1", "Content for Note 1", [ new ImageAttachment("Files/invoice2.png") ])),
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

        SummaryCommand = ReactiveCommand.Create(GenerateSummary);
        TasksCommand = ReactiveCommand.Create(GenerateTasks);
        AutoCompleteCommand = ReactiveCommand.Create(AutoCompleteText);
    }

    private void AutoCompleteText()
    {
        throw new System.NotImplementedException();
    }

    private void GenerateTasks()
    {
        throw new System.NotImplementedException();
    }

    private void GenerateSummary()
    {
        var result = SummarizePy.ExecuteAsync([ SelectedNote.Body ]);

        SelectedNote.Body += "\n\nSummary:\n" + result;
    }

    private async void AddAttachment()
    {
        var filePath = "Files/invoice2.png";
        SelectedNote.Attachments.Add(new AttachmentViewModel(new ImageAttachment(filePath)));
    }

    private void RemoveAttachment(AttachmentViewModel attachment)
    {
        SelectedNote.Attachments.Remove(attachment);
    }

    // Commands
    public ReactiveCommand<Unit, Unit> AddAttachmentCommand { get; }
    public ReactiveCommand<AttachmentViewModel, Unit> RemoveAttachmentCommand { get; }
}
