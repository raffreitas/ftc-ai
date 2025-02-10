using System.Text.Json.Serialization;

namespace FtcAi.DTOs;

public record GeminiAIHttpResponseDto
{
    [JsonPropertyName("candidates")]
    public required IList<Candidate> Candidates { get; init; } = [];
}

public record Candidate
{
    [JsonPropertyName("content")]
    public required Content Content { get; init; }
}
