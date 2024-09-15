﻿namespace AiNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public NoteCollectionViewModel NoteCollection { get; set; } = new();
}
