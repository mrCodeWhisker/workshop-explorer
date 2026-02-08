using Api.Interfaces;
using Api.Models;
using Api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class PlayerEndpoints
{
    public static void UsePlayerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/players");

        group.MapGet("/", GetAllAsync);
        group.MapGet("/{id:int}", GetByIdAsync);
        group.MapPost("/", CreatePlayerAsync);
    }

    private static async Task<IResult> GetAllAsync(IPlayerRepository repository)
    {
        var players = await repository.GetAllAsync();
        return Results.Ok(players);
    }

    private static async Task<IResult> GetByIdAsync(IPlayerRepository repository, int id)
    {
        var player = await repository.GetByIdAsync(id);

        return player == null ? Results.NotFound() : Results.Ok(player);
    }

    private static async Task<IResult> CreatePlayerAsync(IPlayerRepository repository,
        [FromBody] RegisterRequest request)
    {
        if (request.Username == null || request.Password == null)
        {
            return Results.BadRequest();
        }
        
        var player = new Player()
        {
            Username = request.Username,
            CreatedAt =  DateTime.UtcNow,
            CreatedBy = 
        }
        
        await repository.CreateAsync()
    }
}