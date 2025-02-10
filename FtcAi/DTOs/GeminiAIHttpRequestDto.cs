using System.Text.Json.Serialization;

namespace FtcAi.DTOs;

public record GeminiAIHttpRequestDto
{
    [JsonPropertyName("system_instruction")]
    public required SystemInstructions SystemInstructions { get; init; }

    [JsonPropertyName("contents")]
    public required Content Contents { get; init; }
}

public record SystemInstructions(Part Parts);

public record Content
{
    [JsonPropertyName("parts")]
    public IList<Part> Parts { get; init; } = [];
};

public record Part
{
    [JsonPropertyName("text")]

    public required string Text { get; init; }
};
