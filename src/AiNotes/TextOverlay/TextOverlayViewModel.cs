using System.Collections.ObjectModel;
using Avalonia.Media;
using ReactiveUI;

namespace AiNotes.TextOverlay;

 public class TextOverlayViewModel : ReactiveObject
{
    private IImage? _image = null;
    public IImage Image
    {
        get => _image;
        set => this.RaiseAndSetIfChanged(ref _image, value);
    }

    private ObservableCollection<TextRegion> _textRegions = new();
    public ObservableCollection<TextRegion> TextRegions
    {
        get => _textRegions;
        set => this.RaiseAndSetIfChanged(ref _textRegions, value);
    }
}
