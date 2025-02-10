using FtcAi.DTOs;

namespace FtcAi.Services.AI;

public abstract class AIServiceFactory
{
    public abstract IAIService CreateService();

    public Task<AIMessageResponseDto> SendMessage(AIMessageRequestDto message)
    {
        var service = CreateService();
        return service.SendMessage(message);
    }
}
