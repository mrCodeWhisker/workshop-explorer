using Api.Interfaces;
using Api.Models;
using Dapper;

namespace Api.Repositories;

public class PlayerRepository(IDbContext dbContext) : IPlayerRepository
{
    public async Task<List<Player>> GetAllAsync()
    {
        using var connection = dbContext.GetConnection();
        var players = await connection.QueryAsync<Player>("SELECT * FROM player");
        
        return players.ToList();
    }

    public async Task<Player?> GetByIdAsync(int id)
    {
        using var connection = dbContext.GetConnection();
        var player = await 
            connection.QueryFirstOrDefaultAsync<Player>("SELECT * FROM player WHERE id = @id", new { id });
        
        return player;
    }

    public async Task CreateAsync(Player player)
    {
        const string sql = @"INSERT INTO player (id, username, passwordhash, createdby) 
                             VALUES (@id, @username, @passwordhash, @createdby)";
        
        using var connection = dbContext.GetConnection();
        await connection.ExecuteAsync(sql, player);
    }

    public Task UpdateAsync(Player player)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}