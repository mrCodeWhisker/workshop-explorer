using System.Text.Json.Serialization;
using Api.Features.SteamworksApi.Models;
using AutoMapper;

namespace Api.Models.MappingProfiles;

public class SteamApiProfile : Profile
{
    public SteamApiProfile()
    {
        CreateMap<WorkshopCollectionDetails, WorkshopCollection>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.PublishedFileId))
            .ForMember(dest => dest.WorkshopItems, opts => opts.MapFrom(src => src.Children));
        CreateMap<WorkshopCollectionChild, WorkshopItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublishedFileId))
            .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));
        
    }
}