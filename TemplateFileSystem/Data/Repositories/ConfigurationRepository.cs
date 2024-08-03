namespace TemplateFileSystem.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbContexts;
using Models;

public class ConfigurationRepository(ConfigurationContext context) : IConfigurationRepository
{
    public async Task<EndpointConfiguration> GetConfigurationByKeyAsync(string name)
    {
        return await context.Configurations.FirstOrDefaultAsync(c => c.Name == name) ?? new EndpointConfiguration();
    }

    public async Task<IEnumerable<EndpointConfiguration>> GetAllConfigurationsAsync()
    {
        return await context.Configurations.ToListAsync();
    }

    public async Task AddConfigurationAsync(EndpointConfiguration configuration)
    {
        await context.Configurations.AddAsync(configuration);
        await context.SaveChangesAsync();
    }

    public async Task UpdateConfigurationAsync(EndpointConfiguration configuration)
    {
        context.Configurations.Update(configuration);
        await context.SaveChangesAsync();
    }

    public async Task DeleteConfigurationAsync(int id)
    {
        EndpointConfiguration? configuration = await context.Configurations.FindAsync(id);
        if (configuration != null)
        {
            context.Configurations.Remove(configuration);
            await context.SaveChangesAsync();
        }
    }
} // End ConfigurationRepository