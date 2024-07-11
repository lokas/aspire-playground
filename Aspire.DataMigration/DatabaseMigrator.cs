using System.Reflection;
using DbUp;

namespace Migration;

public class DatabaseMigrator(PostGresConnection postGresConnection, ILogger<DatabaseMigrator> log)
{
    public void ExecuteMigrations()
    {
        log.LogInformation("Starting db migration!");
        log.LogInformation("Ensuring db!");
        EnsureDatabase.For.PostgresqlDatabase(postGresConnection.ConnectionString);

        var upgraded =  DeployChanges.To
                .PostgresqlDatabase(postGresConnection.ConnectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        var result = upgraded.PerformUpgrade();
        
        if (!result.Successful)
        {
            log.LogError(result.Error, "Error while migrating db");
            throw result.Error;
        }
    }
}