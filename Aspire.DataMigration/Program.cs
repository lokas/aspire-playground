using WorkerService1;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<MigrateWorker>();


string? conStr = builder.Configuration["ConnectionStrings:postGressDb"];
builder.Services.AddSingleton<DatabaseMigrator>();
builder.Services.AddSingleton<PostGresConnection>(p => new PostGresConnection(conStr));


var host = builder.Build();
try
{
    await host.RunAsync();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

public record PostGresConnection (string ConnectionString);