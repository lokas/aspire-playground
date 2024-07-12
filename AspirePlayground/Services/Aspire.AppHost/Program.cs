using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var psqlPass = builder.AddParameter("psql-pass", secret: true);
var psqlPort = builder.AddParameter("psql-port");

//hm there was some class with naming of resource postgres and default db it created 
//builder.AddPostgres()
var postGres = builder.AddPostgres("postGressRes", password: psqlPass)
    //.WithEnvironment() // username, sqlPassword
    .WithDataVolume() //turns out it does not like when u add volume very annoying
    // below is annoying as well, if you create binding without your name you got 2 tcp and then it throws an error with 
    //our own name it works it binds to the same port 
    .WithEndpoint(port: int.Parse(psqlPort.Resource.Value), targetPort: 5432, name:"mybindings")
    .WithPgAdmin();

var postDb = postGres.AddDatabase("postGressDb");

var cache = builder.AddRedis("cache");


var apiService = builder
    .AddProject<Aspire_ApiService>("apiservice")
    .WithReference(postDb);


builder.AddProject<Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();