using System.Data;

namespace Shared.Migrations;

/// <summary>
/// Dapper context
/// </summary>
public interface IDapperContext
{
    /// <summary>
    /// Create connection
    /// </summary>
    /// <returns> Connection </returns>
    IDbConnection CreateConnection();
}