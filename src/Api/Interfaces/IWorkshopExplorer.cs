using Api.Models;

namespace Api.Interfaces;

public interface IWorkshopExplorer
{
    Task<List<WorkshopCollection>> GetCollectionDetails(List<string> collectionIds);
}