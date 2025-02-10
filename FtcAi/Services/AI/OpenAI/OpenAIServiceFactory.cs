using FtcAi.Settings;

namespace FtcAi.Services.AI.OpenAI;

public class OpenAIServiceFactory : AIServiceFactory
{
    private readonly OpenAISettings _openAISettings;

    public OpenAIServiceFactory(OpenAISettings openAISettings)
    {
        _openAISettings = openAISettings;
    }

    public override IAIService CreateService()
    {
        return new OpenAIService(_openAISettings);
    }
}
