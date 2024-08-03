namespace TemplateFileSystem.Presentation.Views;

using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(ConfigurationView configurationView)
    {
        InitializeComponent();
        MainContent.Content = configurationView;
    }
}