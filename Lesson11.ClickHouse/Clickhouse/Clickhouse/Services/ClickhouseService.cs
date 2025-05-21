namespace Clickhouse.Services;

public class ClickhouseService(IConfiguration config)
{
    private readonly string _connectionString =
        $"Host=localhost;Protocol=https;Port=8443;Username={config["Clickhouse:User"]};Password={config["Clickhouse:Password"]}";
    
    
}