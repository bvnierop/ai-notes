using System.Collections.ObjectModel;
using AiNotes.Models;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private Note _selectedNote;
    public Note SelectedNote
    {
        get => _selectedNote;
        set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
    }

    public ObservableCollection<Note> Notes { get; set; }

    // Constructor
    public MainWindowViewModel()
    {
        Notes = new ObservableCollection<Note>
        {
            new Note("Note 1", "Content for Note 1"),
            new Note("Note 2", "Content for Note 2"),
            new Note("Note 3", "Content for Note 3")
        };

        // Set a default selection (first note)
        if (Notes.Count > 0)
        {
            SelectedNote = Notes[0];
        }
    }
}
