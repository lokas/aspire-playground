using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithEndpoint(63922, 6379);

var psqlPass = builder.AddParameter("psql-pass", secret: true);
//var sqlPassword = builder.AddParameter("sql-password", secret: true);


// var sqlDb = builder.AddSqlServer("sqlServerRes", password: sqlPassword)
//     .WithDataVolume()
//     //.WithEndpoint()
//     .AddDatabase("SqlAspire"); // this is strange you can not reference class lib does not recognise it 

//hm there was some class with naming of resource postgres and default db it created 
//builder.AddPostgres()
var postGres = builder.AddPostgres("postGressRes", password: psqlPass)
    //.WithEnvironment() // username, sqlPassword
    //.WithDataBindMount("./data/postgres")
    //.WithBindMount("/data/postgres", "/var/lib/postgresql/data")
   // .WithEndpoint(63925, 5432)
    .WithPgAdmin();
  //  .WithEndpoint(63926, 80);
//.WithEnvironment("PGUSER", "postgres");

var postDb = postGres.AddDatabase("postGressDb");

var apiService = builder
    .AddProject<Aspire_ApiService>("apiservice")
    .WithReference(postDb);


builder.AddProject<Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();