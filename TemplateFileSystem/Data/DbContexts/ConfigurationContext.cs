namespace TemplateFileSystem.Data.DbContexts;

using Microsoft.EntityFrameworkCore;
using Models;

public class ConfigurationContext(DbContextOptions<ConfigurationContext> options) : DbContext(options)
{
    public DbSet<EndpointConfiguration> Configurations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configuraciones adicionales de modelos

        modelBuilder.Entity<EndpointConfiguration>(entity =>
        {
            entity.ToTable("TblConfiguration");
            entity.Property(e => e.Name).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(200).IsUnicode(false);
        });

        // Datos por defecto para EndpointConfiguration
        modelBuilder.Entity<EndpointConfiguration>().HasData(
            new EndpointConfiguration { Id = 1, Name = "Endpoint1", Url = "https://endpoint1.com" },
            new EndpointConfiguration { Id = 2, Name = "Endpoint2", Url = "https://endpoint2.com" }
        );
    }
} // End ConfigurationContext