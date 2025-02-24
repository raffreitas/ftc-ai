using FtcAi.DTOs;
using FtcAi.Settings;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace FtcAi.Services.AI.OpenAI;

public class OpenAIService : IAIService
{
    private readonly ChatClient _chatClient;
    public OpenAIService(IOptions<OpenAISettings> settings)
    {
        _chatClient = new ChatClient(model: settings.Value.Model, apiKey: settings.Value.ApiKey);
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
