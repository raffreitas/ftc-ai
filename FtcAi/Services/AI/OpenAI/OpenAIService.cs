using FtcAi.DTOs;
using FtcAi.Settings;
using OpenAI.Chat;

namespace FtcAi.Services.AI.OpenAI;

public class OpenAIService : IAIService
{
    private readonly ChatClient _chatClient;
    public OpenAIService(OpenAISettings settings)
    {
        _chatClient = new ChatClient(model: settings.Model, apiKey: settings.ApiKey);
    }
    public async Task<AIMessageResponseDto> SendMessage(AIMessageRequestDto request)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(request.SystemMessage),
            new UserChatMessage(request.UserMessage)
        };

        var completion = await _chatClient.CompleteChatAsync(messages);

        return new AIMessageResponseDto
        {
            Data = completion.Value.Content[0].Text
        };
    }
}
