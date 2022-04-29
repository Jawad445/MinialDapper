using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string procedureName,
        U procedureParams,
        string ConnectionName = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(ConnectionName));
        return await connection.QueryAsync<T>(procedureName, procedureParams, commandType: CommandType.StoredProcedure);
    }

    public async Task Save<T>(string procedureName,
        T procedureParams,
        string ConnectionName = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(ConnectionName));
        await connection.ExecuteAsync(procedureName, procedureParams, commandType: CommandType.StoredProcedure);
    }
}

