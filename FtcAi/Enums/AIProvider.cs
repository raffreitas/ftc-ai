using System.ComponentModel;

namespace FtcAi.Enums;

public enum AIProvider
{
    [Description("OpenAI")]
    OpenAI = 0,
    [Description("Gemini")]
    Gemini = 1,
}
