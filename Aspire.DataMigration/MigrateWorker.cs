namespace WorkerService1;

public class MigrateWorker(DatabaseMigrator migrator) : BackgroundService
{
    private readonly DatabaseMigrator _migrator = migrator;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            

            await Task.Delay(1000, stoppingToken);
        }
    }
}