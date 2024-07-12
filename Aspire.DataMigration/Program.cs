using Migration;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<MigrateWorker>();

var cts = new CancellationTokenSource();

string? conStr = builder.Configuration["ConnectionStrings:postGressDb"];
if(conStr == null)
{
    Console.WriteLine("Connection string not found! Set it in configuration!");
    return;
}

builder.Services.AddSingleton<DatabaseMigrator>();
builder.Services.AddSingleton<PostGresConnection>(_ => new PostGresConnection(conStr));
builder.Services.AddSingleton(_ = cts);

var host = builder.Build();
try
{
    await host.RunAsync(cts.Token);
    Console.WriteLine("Migration completed!");
}
catch (Exception e)
{
    Console.WriteLine("Migration exploded!");
    Console.WriteLine(e);
}

public record PostGresConnection(string ConnectionString);