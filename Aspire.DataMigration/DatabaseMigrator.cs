namespace WorkerService1;

public class DatabaseMigrator(PostGresConnection postGresConnection, ILogger<DatabaseMigrator> log)
{
    private readonly PostGresConnection _connectionString = postGresConnection;
    private readonly ILogger<DatabaseMigrator> _log = log;

    public async void ExecuteMigrations()
    {
        _log.LogInformation("Starting db migration: {time}", DateTimeOffset.Now);
        _log.LogWarning("ops");
    }
}