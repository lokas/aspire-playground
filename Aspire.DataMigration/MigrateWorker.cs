using Migration;

public class MigrateWorker(DatabaseMigrator migrator, CancellationTokenSource cts) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        migrator.ExecuteMigrations();
        cts.Cancel();
        return Task.CompletedTask;
    }
}