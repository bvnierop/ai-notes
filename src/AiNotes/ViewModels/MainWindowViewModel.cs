namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => """
                              # Heading1

                              Hello Markdown.Avalonia!

                              * listitem1
                              * listitem2

                              | col1 | col2 | col3 |
                              |------|------|------|
                              | one  |------|------|
                              | two  |------|------|                         
                              """;

    public NoteCollectionViewModel NoteCollection { get; set; } = new();
}
