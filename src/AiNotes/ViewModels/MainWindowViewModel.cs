using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text.Json;
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


    private string _searchTerm;
    public string SearchTerm {
        get => _searchTerm;
        set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
    }

    public ObservableCollection<NoteViewModel> Notes { get; set; }

     // Commands for the buttons
     public ICommand SummaryCommand { get; }
     public ICommand TasksCommand { get; }
     public ICommand AutoCompleteCommand { get; }
     public ICommand SearchCommand { get; }

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
        SearchCommand = ReactiveCommand.Create(Search);
    }

    private record SearchThingy(int id, string title, string content)
    {
        public static SearchThingy OfNoteViewModel(int index, NoteViewModel note)
        {
            return new SearchThingy(index, note.Title, note.Body);
        }
    }
    private record SearchJson(string term, SearchThingy[] notes);

    private void Search()
    {
        // Search with SearchTerm
        //  1. Convert documents to json in the following format
        // {
        //    id: 1,
        //    title: "Note 1",
        //    body: "Content for Note 1"
        // }
        //
        // Pass that as input to python script
        // Concat the result to the end of the current note
        var searchThingies = Notes.Select((model, i) => SearchThingy.OfNoteViewModel(i, model)).ToList();
        var searchJson = new SearchJson(SearchTerm, searchThingies.ToArray());
        var result = ExecutePy.Execute("search", [ JsonSerializer.Serialize(searchJson) ]);

        SelectedNote.Body += "\n\n" + result;
    }

    private void AutoCompleteText()
    {
        throw new System.NotImplementedException();
    }

    private void GenerateTasks()
    {
        var result = ExecutePy.Execute("todos", [ SelectedNote.Body ]);

        SelectedNote.Body += "\n\n" + result;
    }

    private void GenerateSummary()
    {
        var result = ExecutePy.Execute("summarize", [ SelectedNote.Body ]);

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
