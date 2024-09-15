using System.Collections.Generic;

namespace AiNotes.ViewModels;

public class NoteCollectionViewModel
{
    List<NoteViewModel> Notes { get; set; } = new();
}
