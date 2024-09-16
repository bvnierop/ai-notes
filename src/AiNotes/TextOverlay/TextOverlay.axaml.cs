using Avalonia;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using Avalonia.Media.Imaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Media;

namespace AiNotes.TextOverlay;

public partial class TextOverlay : UserControl
{
    public TextOverlay()
    {
        InitializeComponent();

        this.LayoutUpdated += (sender, e) =>
        {
            if (DataContext is TextOverlayViewModel viewModel)
            {
                viewModel.ControlWidth = this.Image.Bounds.Width;
                viewModel.ControlHeight = this.Image.Bounds.Height;
                viewModel.Normalize();
            }
        };
    }
}
