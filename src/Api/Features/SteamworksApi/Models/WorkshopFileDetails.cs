using System.Text.Json.Serialization;

namespace Api.Features.SteamworksApi.Models;

public class WorkshopFileDetails
{
    public ulong PublishedFileId { get; set; }
    public int Result { get; set; }
    public ulong Creator { get; set; }
    [JsonPropertyName("creator_app_id")]
    public int CreatorAppId { get; set; }
    [JsonPropertyName("consumer_app_id")]
    public int ConsumerAppId { get; set; }
    public string? FileName { get; set; }
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }
    [JsonPropertyName("file_url")]
    public string? FileUrl { get; set; }
    [JsonPropertyName("preview_url")]
    public string? PreviewUrl { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public long TimeCreated { get; set; }
    public long TimeUpdated { get; set; }
    public int Visibility { get; set; }
    public bool Banned { get; set; }
    public int Subscriptions { get; set; }
    public int Favorited { get; set; }
    public int LifetimeSubscriptions { get; set; }
    public int LifetimeFavorited { get; set; }
    public int Views { get; set; }
    public List<WorkshopTag> Tags { get; set; } = new();
}
