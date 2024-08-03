using System.ComponentModel.DataAnnotations;

namespace TemplateFileSystem.Data.Models;

public class EndpointConfiguration
{
    public int Id { get; init; }

    [StringLength(10)] public string? Name { get; init; }

    [StringLength(100)] public string? Url { get; init; }
}