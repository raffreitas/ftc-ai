using FtcAi.Enums;
using System.ComponentModel.DataAnnotations;

namespace FtcAi.DTOs;

public record AnalysisRequestDto
{
    [Required, MinLength(1)]
    public IEnumerable<object> Data { get; init; } = [];

    [Required, EnumDataType(typeof(AIProvider))]
    public AIProvider Provider { get; init; }
}
