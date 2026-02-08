using System.Data;
using Api.Interfaces;
using Npgsql;

namespace Api.Config;

public class DbContext : IDbContext
{
    private IDbConnection? _connection;
    private readonly string _connectionString;

    public DbContext()
    {
        _connectionString = "host=localhost; database=workshop_explorer; username=postgres; password=223Kx$7*T@Smv9";
    }

    public IDbConnection GetConnection()
    {
        if (_connection is not { State: ConnectionState.Open })
        {
            _connection = new NpgsqlConnection(_connectionString);
        }

        return _connection;
    }
}