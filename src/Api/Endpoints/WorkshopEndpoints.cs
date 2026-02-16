using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class WorkshopEndpoints
{
    public static void UseWorkshopEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/workshop");

        group.MapGet("/", GetAllWorkshopGamesAsync);
    }

    private static async Task<IResult> GetAllWorkshopGamesAsync(
        [FromServices] IWorkshopExplorer workshopExplorer,
        [FromQuery] string[] collectionIds
    )
    {
        if (collectionIds.Length == 0)
        {
            return Results.BadRequest();
        }
        
        var collections = await workshopExplorer.GetCollectionDetails(collectionIds.ToList());
        
        return Results.Ok(collections);
    }
}