namespace TemplateFileSystem.Data.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IConfigurationRepository
{
    Task<EndpointConfiguration> GetConfigurationByKeyAsync(string name);
    Task<IEnumerable<EndpointConfiguration>> GetAllConfigurationsAsync();
    Task AddConfigurationAsync(EndpointConfiguration configuration);
    Task UpdateConfigurationAsync(EndpointConfiguration configuration);
    Task DeleteConfigurationAsync(int id);
}