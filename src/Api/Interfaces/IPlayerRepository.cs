using Api.Models;
using Api.Models.Request;

namespace Api.Interfaces;

public interface IPlayerRepository
{
    Task<List<Player>> GetAllAsync();
    Task<Player?> GetByIdAsync(int id);
    Task UpsertAsync(UpsertPlayerRequest request);
    Task DeleteAsync(int id);
}