using k8s.Models;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var psqlPass = builder.AddParameter("psql-pass", secret: true);
var sqlPassword = builder.AddParameter("sql-password", secret: true);

var db = builder.AddSqlServer("sqlServer", password: sqlPassword)
    .WithDataVolume()
    //.WithEndpoint()
    .AddDatabase("SqlAspire"); // this is strange you can not reference class lib does not recognise it 

//hm there was some class with naming of resource postgres and default db it created 
var postGress = builder.AddPostgres("postGressRes", password: psqlPass)
    //.WithEnvironment() // username, sqlPassword
    .WithDataVolume()
    .WithPgAdmin();
    //.WithEnvironment("PGUSER", "postgres");

var postDb = postGress.AddDatabase("postGressDb");

var apiService = builder
    .AddProject<AspireStarterApplicaitonPlayground_ApiService>("apiservice")
    .WithReference(postDb);

builder.AddProject<AspireStarterApplicaitonPlayground_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();