namespace TemplateFileSystem.Business.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

public interface IConfigurationService
{
    Task<EndpointConfiguration> GetConfigurationByKeyAsync(string name);
    Task<IEnumerable<EndpointConfiguration>> GetAllConfigurationsAsync();
    Task AddConfigurationAsync(EndpointConfiguration configuration);
    Task UpdateConfigurationAsync(EndpointConfiguration configuration);
    Task DeleteConfigurationAsync(int id);
}