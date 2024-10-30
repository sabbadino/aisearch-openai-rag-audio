using Azure.AI.OpenAI;
using backendnet;
using backendnet.Controllers;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//var endpoint = builder.Configuration["AZURE_OPENAI_ENDPOINT"];
//ArgumentException.ThrowIfNullOrEmpty(endpoint, nameof(endpoint));
//var azureOpenAiApiKey = builder.Configuration["AZURE_OPENAI_API_KEY"];
//ArgumentException.ThrowIfNullOrEmpty(azureOpenAiApiKey, nameof(azureOpenAiApiKey));
//AzureOpenAIClient client = new(new Uri(endpoint), new System.ClientModel.ApiKeyCredential(azureOpenAiApiKey));
//builder.Services.AddSingleton(client);
builder.Services.AddScoped<IAiToClientMessageProcessors, AiToClientMessageProcessors>();
builder.Services.AddScoped<IWeatherProvider, WeatherProvider>();
builder.Services.AddScoped<IClientToAiMessageProcessors, ClientToAiMessageProcessors>();

builder.Services.AddScoped<IMessageParser, MessageParser>();
builder.Services.AddHttpClient();   

builder.Services.AddOptions<RealTimeAudioSettings>().Bind(builder.Configuration.GetSection(nameof(RealTimeAudioSettings)));

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.Run();
