using FtcAi.Enums;
using FtcAi.Services.AI.Gemini;
using FtcAi.Services.AI.OpenAI;

namespace FtcAi.Services.AI;

public class AIServiceFactory
{
    private readonly OpenAIService _openAiService;
    private readonly GeminiService _geminiService;

    public AIServiceFactory(OpenAIService openAiService, GeminiService geminiService)
    {
        _openAiService = openAiService;
        _geminiService = geminiService;
    }

    public IAIService CreateService(AIProvider provider)
    {
        return provider switch
        {
            AIProvider.OpenAI => _openAiService,
            AIProvider.Gemini => _geminiService,
            _ => throw new ArgumentOutOfRangeException(nameof(provider), provider, null),
        };
    }
}
