using System.Data;

namespace Api.Interfaces;

public interface IDbContext
{
    IDbConnection GetConnection();
}