using System.Data;
using Api.Interfaces;
using Api.Models;
using Api.Models.Request;
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

    public async Task UpsertAsync(UpsertPlayerRequest request)
    {
        using var connection = dbContext.GetConnection();
        
        await connection.ExecuteAsync(
            "SELECT player_upsert(@Id, @Username, @PasswordHash, @IsDeleted, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy);",
            request
        );
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