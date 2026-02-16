namespace Api.Features.SteamworksApi.Models.Request;

public class GetCollectionDetailsRequest
{
    public int CollectionCount => PublishedFileIds?.Count ?? 0;
    public List<string> PublishedFileIds { get; set; } = new();
}