using Api.Config;
using Api.Endpoints;
using Api.Features.SteamworksApi.Services;
using Api.Models.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGlobalDependencies(builder.Configuration);
builder.Services.AddHttpClient<SteamWorkshopExplorer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UsePlayerEndpoints();
app.UseWorkshopEndpoints();

app.UseHttpsRedirection();

app.Run();