using WorkerService1;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<MigrateWorker>();


string? conStr = builder.Configuration["ConnectionStrings:postGressDb"];
builder.Services.AddSingleton<DatabaseMigrator>();
builder.Services.AddSingleton<PostGresConnection>(p => new PostGresConnection(conStr));

try
{
    var host = builder.Build();
    host.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

public record PostGresConnection (string ConnectionString);