using FtcAi.Settings;

namespace FtcAi.Services.AI.Gemini;

public class GeminiServiceFactory : AIServiceFactory
{
    private readonly IHttpClientFactory _httpContextFactory;
    private readonly GeminiSettings _geminiSettings;

    public GeminiServiceFactory(IHttpClientFactory httpContextFactory, GeminiSettings geminiSettings)
    {
        _httpContextFactory = httpContextFactory;
        _geminiSettings = geminiSettings;
    }

    public override IAIService CreateService()
    {
        return new GeminiService(_httpContextFactory, _geminiSettings);
    }
}
