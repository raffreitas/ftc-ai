using FtcAi.DTOs;
using FtcAi.Services.Analysis;
using Microsoft.AspNetCore.Mvc;

namespace FtcAi.Controllers;

[ApiController]
[Route("api/analysis")]
public class AnalysisController : ControllerBase
{
    private readonly IAnalysisService _analysisService;

    public AnalysisController(IAnalysisService analysisService)
    {
        _analysisService = analysisService;
    }

    [HttpPost("v1")]
    [ProducesResponseType(typeof(AnalysisResponseDto), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post([FromBody] AnalysisRequestDto request)
    {
        var result = await _analysisService.Analyze(request);
        return Ok(result);
    }
}
