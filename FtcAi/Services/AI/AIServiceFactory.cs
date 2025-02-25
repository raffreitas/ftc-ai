using FtcAi.Enums;
using FtcAi.Services.AI.Gemini;
using FtcAi.Services.AI.OpenAI;

namespace FtcAi.Services.AI;

public class AIServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AIServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAIService CreateService(AIProvider provider)
    {
        return provider switch
        {
            AIProvider.OpenAI => _serviceProvider.GetRequiredService<OpenAIService>(),
            AIProvider.Gemini => _serviceProvider.GetRequiredService<GeminiService>(),
            _ => throw new ArgumentOutOfRangeException(nameof(provider), provider, null),
        };
    }
}
