namespace Clickhouse.Services;

public interface IClickhouseWrapper
{
    public Task CreateTableIfNotExistAsync();
    public Task DropTableAsync();
}