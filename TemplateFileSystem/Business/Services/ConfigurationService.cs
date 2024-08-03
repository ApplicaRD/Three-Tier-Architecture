namespace TemplateFileSystem.Business.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Data.Models;
using Data.Repositories;

internal class ConfigurationService(IConfigurationRepository configurationRepository) : IConfigurationService
{
    public async Task<EndpointConfiguration> GetConfigurationByKeyAsync(string name)
    {
        return await configurationRepository.GetConfigurationByKeyAsync(name);
    }

    public async Task<IEnumerable<EndpointConfiguration>> GetAllConfigurationsAsync()
    {
        return await configurationRepository.GetAllConfigurationsAsync();
    }

    public async Task AddConfigurationAsync(EndpointConfiguration configuration)
    {
        await configurationRepository.AddConfigurationAsync(configuration);
    }

    public async Task UpdateConfigurationAsync(EndpointConfiguration configuration)
    {
        await configurationRepository.UpdateConfigurationAsync(configuration);
    }

    public async Task DeleteConfigurationAsync(int id)
    {
        await configurationRepository.DeleteConfigurationAsync(id);
    }
} // end class ConfigurationService