using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;
using Clickhouse.Models;

namespace Clickhouse.Services;

public class ClickhouseService(IConfiguration config)
{
    private const string TableName = "Users";

    private readonly string _connectionString =
        $"Host=localhost;Protocol=https;Port=8443;Username={config["Clickhouse:User"]};Password={config["Clickhouse:Password"]}";

    private ClickHouseConnection GetConnection()
    {
        return new ClickHouseConnection(_connectionString);
    }

    public async Task CreateTableIfNotExistAsync()
    {
        const string sql = $"""

                                        CREATE TABLE IF NOT EXISTS {TableName} (
                                            Id UInt32,
                                            Name String,
                                            Age UInt16,
                                            TotalSpending Decimal,
                                        ) ENGINE = MergeTree()
                                        ORDER BY Id
                            """;

        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        await command.ExecuteNonQueryAsync();
    }

    public async Task DropTableAsync()
    {
        const string sql = $"DROP TABLE IF EXISTS {TableName}";
        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        await command.ExecuteNonQueryAsync();
    }

    public async Task<int> InsertAsync(User user)
    {
        const string sql =
            $"INSERT INTO {TableName} (Id, Name, Age, TotalSpending) VALUES ({{id:UInt32, name:String, age:UInt16, totalSpending:Decimal}})";
        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();

        command.CommandText = sql;
        command.AddParameter("id", user.Id);
        command.AddParameter("name", user.Name);
        command.AddParameter("age", user.Age);
        command.AddParameter("totalSpending", user.TotalSpending);

        return await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteByIdAsync(uint id)
    {
        const string sql = $"ALTER TABLE {TableName} DELETE WHERE Id = {{id:UInt32}}";
        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.AddParameter("id", id);
        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<User>> SearchByNameAsync(string name)
    {
        const string sql = $"SELECT Id, Name, Age FROM {TableName} WHERE Name = {{name:String}}";
        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.AddParameter("name", name);

        await using var reader = await command.ExecuteReaderAsync();
        var results = new List<User>();
        while (await reader.ReadAsync())
            results.Add(new User
            {
                Id = (uint)reader.GetValue(0),
                Name = reader.GetString(1),
                Age = (ushort)reader.GetValue(2),
                TotalSpending = reader.GetDecimal(3)
            });
        return results;
    }

    public async Task<List<User>> SearchWithConditionsAsync(
        string name,
        byte age,
        bool useAnd = true)
    {
        var op = useAnd ? "AND" : "OR";
        var sql = $"SELECT Id, Name, Age FROM {TableName} WHERE Name = {{name:String}} {op} Age = {{age:UInt16}}";
        await using var connection = GetConnection();
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.AddParameter("name", name);
        command.AddParameter("age", age);

        await using var reader = await command.ExecuteReaderAsync();
        var results = new List<User>();
        while (await reader.ReadAsync())
            results.Add(new User
            {
                Id = (uint)reader.GetValue(0),
                Name = reader.GetString(1),
                Age = (ushort)reader.GetValue(2),
                TotalSpending = reader.GetDecimal(3)
            });
        return results;
    }
}