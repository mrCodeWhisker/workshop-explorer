using Api.Models;

namespace Api.Interfaces;

public interface IPlayerRepository
{
    Task<List<Player>> GetAllAsync();
    Task<Player?> GetByIdAsync(int id);
    Task CreateAsync(Player player);
    Task UpdateAsync(Player player);
    Task DeleteAsync(int id);
}