using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Shared.Migrations;

/// <summary>
/// Dapper context
/// </summary>
public class DapperContext : IDapperContext
{
    private readonly string? _connectionString;
    
    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    /// <summary>
    /// Create connection
    /// </summary>
    /// <returns> Connection </returns>
    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}