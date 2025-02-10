using FtcAi.DTOs;
using FtcAi.Settings;
using System.Text.Json;

namespace FtcAi.Services.AI.Gemini;

public class GeminiService : IAIService
{
    private readonly HttpClient _httpClient;
    private readonly GeminiSettings _geminiSettings;
    public GeminiService(IHttpClientFactory httpClient, GeminiSettings geminiSettings)
    {
        _httpClient = httpClient.CreateClient();
        _geminiSettings = geminiSettings;
    }

    public async Task<AIMessageResponseDto> SendMessage(AIMessageRequestDto message)
    {
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/{_geminiSettings.Model}:generateContent?key={_geminiSettings.ApiKey}";
        _httpClient.BaseAddress = new Uri(url);

        var request = new GeminiAIHttpRequestDto
        {
            SystemInstructions = new SystemInstructions(new Part { Text = message.SystemMessage }),
            Contents = new Content
            {
                Parts = [new Part { Text = message.UserMessage }]
            },
        };

        var response = await _httpClient.PostAsJsonAsync("", request);

        response.EnsureSuccessStatusCode();

        var geminiResponse = JsonSerializer.Deserialize<GeminiAIHttpResponseDto>(await response.Content.ReadAsStringAsync());

        return new AIMessageResponseDto
        {
            Data = geminiResponse.Candidates[0].Content.Parts[0].Text,
        };
    }
}
