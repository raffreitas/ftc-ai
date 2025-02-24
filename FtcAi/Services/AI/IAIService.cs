using FtcAi.DTOs;

namespace FtcAi.Services.AI;

public interface IAIService
{
    Task<AIMessageResponseDto> SendMessage(AIMessageRequestDto message);
}
