using FtcAi.DTOs;

namespace FtcAi.Services.Analysis;

public interface IAnalysisService
{
    Task<AnalysisResponseDto> Analyze(AnalysisRequestDto request);
}
