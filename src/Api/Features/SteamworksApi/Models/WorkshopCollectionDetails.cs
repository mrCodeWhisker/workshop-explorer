namespace Api.Features.SteamworksApi.Models;

public class WorkshopCollectionDetails
{
    public string PublishedFileId { get; set; }
    public int Result { get; set; }
    public List<WorkshopCollectionChild> Children { get; set; } = new();
}
