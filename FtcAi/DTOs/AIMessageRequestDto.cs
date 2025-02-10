namespace FtcAi.DTOs;

public record AIMessageRequestDto
{
    public required string UserMessage { get; init; }
    public string SystemMessage { get; init; } = string.Empty;
};