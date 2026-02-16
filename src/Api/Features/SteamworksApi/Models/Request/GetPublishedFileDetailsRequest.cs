namespace Api.Features.SteamworksApi.Models.Request;

public class GetPublishedFileDetailsRequest
{
    public int ItemCount => PublishedFileIds?.Count ?? 0;
    public List<string> PublishedFileIds { get; set; } = new();
}