using System.Collections.ObjectModel;
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
            new(new Note("Note 1", "Content for Note 1")),
            new(new Note("Note 2", "Content for Note 2")),
            new(new Note("Note 3", "Content for Note 3"))
        };

        // Set a default selection (first note)
        if (Notes.Count > 0)
        {
            SelectedNote = Notes[0];
        }
    }
}
