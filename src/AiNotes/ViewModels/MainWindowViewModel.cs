using System.Collections.ObjectModel;
using ReactiveUI;

namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _selectedNoteTitle;
    private string _selectedNoteBody;

    public ObservableCollection<string> NoteTitles { get; set; }

    // Property for the currently selected note title
    public string SelectedNoteTitle
    {
        get => _selectedNoteTitle;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedNoteTitle, value);
            // When a new note is selected, update the content
            if (value != null)
            {
                // Simulate loading content (in a real scenario, load from a data source)
                SelectedNoteBody = $"This is the content of '{value}'";
            }
        }
    }

    // Property for the selected note's content
    public string SelectedNoteBody
    {
        get => _selectedNoteBody;
        set => this.RaiseAndSetIfChanged(ref _selectedNoteBody, value);
    }

    // Constructor
    public MainWindowViewModel()
    {
        // Simulate loading notes (in a real scenario, load from a data source)
        NoteTitles = new ObservableCollection<string>
        {
            "Note 1",
            "Note 2",
            "Note 3"
        };

        // Set a default selection (first note)
        if (NoteTitles.Count > 0)
        {
            SelectedNoteTitle = NoteTitles[0];
        }
    }
}
