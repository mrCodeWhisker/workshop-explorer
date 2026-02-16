using System.Text;
using System.Text.Json;
using Api.Features.SteamworksApi.Models;
using Api.Features.SteamworksApi.Models.Response;
using Api.Interfaces;
using Api.Models;
using Api.Models.MappingProfiles;
using AutoMapper;

namespace Api.Features.SteamworksApi.Services;

public class SteamWorkshopExplorer(HttpClient httpClient, IMapper mapper) : IWorkshopExplorer
{
    private readonly string _steamworksBaseUrl = "https://api.steampowered.com";

    public async Task<List<WorkshopCollection>> GetCollectionDetails(List<string> collectionIds)
    {
        if (collectionIds.Count == 0) return [];
        try
        {
            var url = BuildApiUrl("ISteamRemoteStorage", ["GetCollectionDetails"]);
            
            var request = new Dictionary<string, object>()
            {
                { "collectioncount",  collectionIds.Count.ToString() },
                { "publishedfileids", collectionIds }
            };

            var response = await PostAsync<GetCollectionDetailsResponse>(url, request);
            var result = mapper.Map<List<WorkshopCollection>>(response.Response.CollectionDetails);
            
            var allWorkshopItems = result.SelectMany(c => c.WorkshopItems).ToList();
            
            var publishedFileIds = allWorkshopItems
                .Select(w => w.Id)
                .Where(id => !string.IsNullOrEmpty(id))
                .Distinct()
                .ToList();
            
            var detailsById = (await GetPublishedFileDetails(publishedFileIds))
                .ToDictionary(x => x.PublishedFileId);
            
            foreach (var item in allWorkshopItems)
            {
                if (detailsById.TryGetValue(item.Id, out var details))
                    item.Details = details;
            }
            
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public async Task<List<PublishedFileDetails>> GetPublishedFileDetails(List<string> fileIds)
    {
        if (fileIds.Count == 0) return [];

        try
        {
            var url = BuildApiUrl("ISteamRemoteStorage", ["GetPublishedFileDetails"]);
            
            var request = new Dictionary<string, object>()
            {
                { "itemcount",  fileIds.Count.ToString() },
                { "publishedfileids", fileIds }
            };

            var response = await PostAsync<GetPublishedFileDetailsResponse>(url, request);

            return response.Response.PublishedFileDetails;
            // return mapper.Map<List<WorkshopCollection>>(response.Response.CollectionDetails);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    private async Task<T> PostAsync<T>(string url, Dictionary<string, object> body)
    {
        var kvp = new List<KeyValuePair<string, string>>();

        foreach (var (key, value) in body)
        {
            if (value.GetType() == typeof(string))
            {
                kvp.Add(new KeyValuePair<string, string>(key, value.ToString()));
            }
            else if (value.GetType() == typeof(List<string>))
            {
                var enumerable = (IEnumerable<string>)value;

                var count = 0;
                var items = enumerable.Select(item => new KeyValuePair<string, string>($"{key}[{count++}]", item.ToString())).ToList();

                kvp.AddRange(items);
            }
        }
        
        var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(kvp) };
        var response = await httpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        
        var result = JsonSerializer.Deserialize<T>(responseBody, jsonOptions);
        
        return result;
    }
    
    private string BuildApiUrl(string apiInterface, object[] args = null) {
        const string version = "v1";
	
        var urlParts = new List<string>();
	
        urlParts.Add(_steamworksBaseUrl);
        urlParts.Add(apiInterface);

        if (args == null)
        {
            urlParts.Add(version);
            return string.Join('/', urlParts);
        }
        
        foreach (var item in args) {
            try {
                urlParts.Add(item.ToString().Trim());
            } catch {}
        }
        
        urlParts.Add(version);

        return string.Join('/', urlParts);
    }
}