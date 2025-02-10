using System.ComponentModel.DataAnnotations;

namespace FtcAi.Settings;

public record OpenAISettings()
{
    [Required]
    [MinLength(1)]
    public string ApiKey { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Model { get; init; } = string.Empty;
}

