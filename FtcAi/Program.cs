using FtcAi.Exceptions;
using FtcAi.Services.AI;
using FtcAi.Services.AI.Gemini;
using FtcAi.Services.AI.OpenAI;
using FtcAi.Services.Analysis;
using FtcAi.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAi"));
builder.Services.Configure<GeminiSettings>(builder.Configuration.GetSection("Gemini"));

builder.Services.AddScoped<OpenAIService>();
builder.Services.AddScoped<GeminiService>();
builder.Services.AddScoped<AIServiceFactory>();

builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddHttpClient();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<AppExceptionHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
