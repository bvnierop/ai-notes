using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text.Json;
using System.Windows.Input;
using AiNotes.Models;
using AiNotes.Scripts;
using Avalonia.Controls;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Window _parentWindow;

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
    public MainWindowViewModel(Window parentWindow)
    {
        _parentWindow = parentWindow;

        var notes = DemoContent.DemoNotes.Select(note => new NoteViewModel(note));

        Notes = new ObservableCollection<NoteViewModel>(notes);

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
        Debug.WriteLine($"AddAttachment: {Environment.CurrentDirectory}");
        var dialog = new OpenFileDialog
        {
            Title = "Select a file to attach",
            Directory = $"{Environment.CurrentDirectory}/Files",
            AllowMultiple = false // Set to true if you want to allow multiple files
        };

        string[]? result = await dialog.ShowAsync(_parentWindow);

        if (result != null && result.Length > 0)
        {
            string selectedFilePath = result[0]; // Get the first selected file
            // Console.WriteLine($"File selected: {selectedFilePath}");

            // Add the file as an attachment (or process it as needed)
            if (selectedFilePath.EndsWith(".jpeg") || selectedFilePath.EndsWith(".jpg") || selectedFilePath.EndsWith(".png"))
                SelectedNote.Attachments.Add(new AttachmentViewModel(new ImageAttachment(selectedFilePath)));
            else if (selectedFilePath.EndsWith(".mp4"))
                AddVideoAttachment(selectedFilePath);
        }
        else
        {
            // Console.WriteLine("No file selected.");
        }


        // var filePath = "Files/marketing.jpeg";
    }

    private void AddVideoAttachment(string selectedFilePath)
    {
        SelectedNote.Attachments.Add(new AttachmentViewModel(new ImageAttachment("Files/avi.png")));
        var result = TranscribePy.ExecuteAsync(selectedFilePath);
        SelectedNote.Body += "\n\nTranscription:\n" + result;
    }

    private void RemoveAttachment(AttachmentViewModel attachment)
    {
        SelectedNote.Attachments.Remove(attachment);
    }

    // Commands
    public ReactiveCommand<Unit, Unit> AddAttachmentCommand { get; }
    public ReactiveCommand<AttachmentViewModel, Unit> RemoveAttachmentCommand { get; }
}
