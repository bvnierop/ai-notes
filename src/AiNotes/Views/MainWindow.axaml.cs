using AiNotes.ViewModels;
using Avalonia.Controls;

namespace AiNotes.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(this);
    }
}
