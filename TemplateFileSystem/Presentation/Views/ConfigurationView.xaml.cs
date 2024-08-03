namespace TemplateFileSystem.Presentation.Views;

using System.Windows.Controls;
using ViewModels;

/// <summary>
/// Interaction logic for ConfigurationView.xaml
/// </summary>
public partial class ConfigurationView : UserControl
{
    public ConfigurationView(ConfigurationViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}