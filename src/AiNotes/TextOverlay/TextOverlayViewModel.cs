using System.Collections.Generic;
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
    public List<TextRegion> OriginalTextRegions { get; set; } = new();

    private double _controlWidth;
    public double ControlWidth
    {
        get => _controlWidth;
        set => this.RaiseAndSetIfChanged(ref _controlWidth, value);
    }

    private double _controlHeight;
    public double ControlHeight
    {
        get => _controlHeight;
        set => this.RaiseAndSetIfChanged(ref _controlHeight, value);
    }

    bool _normalized = false;
    public void Normalize()
    {
        if (double.IsNaN(ControlWidth) || double.IsNaN(ControlHeight)) return;
        if (_normalized) return;
        _normalized = true;

        foreach (var region in OriginalTextRegions)
        {
            TextRegions.Add(new()
            {
                Text = region.Text,
                X = region.X / Image.Size.Width * ControlWidth,
                Y = region.Y / Image.Size.Height * ControlHeight,
                Width = region.Width / Image.Size.Width * ControlWidth,
                Height = region.Height / Image.Size.Height * ControlHeight,
            });
        }
    }
}
