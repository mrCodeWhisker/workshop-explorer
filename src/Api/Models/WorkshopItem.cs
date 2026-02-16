using Api.Features.SteamworksApi.Models;

namespace Api.Models;

public class WorkshopItem
{
    public string Id { get; set; }
    public int FileType { get; set; }
    public PublishedFileDetails? Details { get; set; } = null;
}