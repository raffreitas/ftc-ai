using FtcAi.DTOs;
using FtcAi.Enums;
using FtcAi.Services.AI;
using FtcAi.Services.AI.Gemini;
using FtcAi.Services.AI.OpenAI;
using FtcAi.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace FtcAi.Services.Analysis;

public class AnalysisService : IAnalysisService
{
    private readonly IHttpClientFactory _httpContextFactory;
    private readonly OpenAISettings _openAISettings;
    private readonly GeminiSettings _geminiSettings;

    public AnalysisService(IHttpClientFactory httpContextFactory,
        IOptions<OpenAISettings> openAISettings,
        IOptions<GeminiSettings> geminiSettings)
    {
        _httpContextFactory = httpContextFactory;
        _openAISettings = openAISettings.Value;
        _geminiSettings = geminiSettings.Value;
    }

    public async Task<AnalysisResponseDto> Analyze(AnalysisRequestDto request)
    {
        AIServiceFactory aiServiceFactory = request.Provider switch
        {
            AIProvider.OpenAI => new OpenAIServiceFactory(_openAISettings),
            AIProvider.Gemini => new GeminiServiceFactory(_httpContextFactory, _geminiSettings),
            _ => throw new Exception(),
        };

        var systemMessage = @"
            **Objetivo:** Analisar os dados JSON abaixo para identificar gargalos e oportunidades de melhoria na produtividade dos times de tecnologia.
            **Formato de resposta:** Retorne a análise sempre em português e em formato de texto com as quebras de linhas sendo separadas pelo caractere '\n'.

            **Contexto:**
            *   **Name:** Nome do time de desenvolvimento.
            *   **Tasks:** Lista de tarefas do time.
            *   **Id:** Identificador único da tarefa.
            *   **Title:** Descrição resumida da tarefa.
            *   **Status:** Estado atual da tarefa (ex: ""In progress"", ""Awaiting Deployment"", ""Done"", ""To Do"").
            *   **Assignee:** Nome do membro do time responsável pela tarefa.
            *   **CreationDate:** Data e hora de criação da tarefa (formato ISO 8601).
            *   **UpdateDate:** Data e hora da última atualização da tarefa (formato ISO 8601)

            **Análise***
            * Liste o número de tarefas em cada status para cada time.
            * Calcule o tempo médio de conclusão de tarefas para cada time, considerando apenas as tarefas com status ""Done"".
            * Identifique os membros da equipe com o maior número de tarefas em andamento.
            * Gere um resumo conciso com os principais insights da análise, destacando os pontos fortes e fracos de cada time em relação à produtividade
        ".Trim();

        var result = await aiServiceFactory.SendMessage(new AIMessageRequestDto
        {
            SystemMessage = systemMessage,
            UserMessage = JsonSerializer.Serialize(request.Data)
        });

        return new AnalysisResponseDto(result.Data);
    }
}
