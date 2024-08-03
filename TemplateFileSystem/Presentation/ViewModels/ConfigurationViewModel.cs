namespace TemplateFileSystem.Presentation.ViewModels;

using System.Collections.ObjectModel;
using System.ComponentModel;
using Business.Interfaces;
using Data.Models;

public sealed class ConfigurationViewModel : INotifyPropertyChanged
{
    private readonly IConfigurationService _configurationService;
    private EndpointConfiguration? _selectedConfiguration;
    private ObservableCollection<EndpointConfiguration>? _configurations;

    public EndpointConfiguration SelectedConfiguration
    {
        get => _selectedConfiguration ?? new EndpointConfiguration();
        set
        {
            _selectedConfiguration = value;
            OnPropertyChanged(nameof(SelectedConfiguration));
        }
    }

    public ObservableCollection<EndpointConfiguration> Configurations
    {
        get => _configurations ?? [];
        set
        {
            _configurations = value;
            OnPropertyChanged(nameof(Configurations));
        }
    }

    public ConfigurationViewModel(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
        LoadConfigurations();
    }

    private async void LoadConfigurations()
    {
        IEnumerable<EndpointConfiguration> configurations = await _configurationService.GetAllConfigurationsAsync();
        Configurations = new ObservableCollection<EndpointConfiguration>(configurations);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}