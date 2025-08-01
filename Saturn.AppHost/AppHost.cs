var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.Saturn_ApiService>("apiService")
    .WithHttpHealthCheck("/health");

var inventoryDatabase = builder.AddPostgres("mypostgres").AddDatabase("inventory");
builder.AddProject<Projects.InventoryService>()
       .WithReference(inventoryDatabase);

var db = builder.AddOracle("oracle").AddDatabase("OracleDB");
var myService = builder.AddProject<Projects.MyService>()
                       .WithReference(db);

builder.AddProject<Projects.Saturn_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.Saturn_RobotWindow>("robotwindow")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.Saturn_K8RoboFleet>("kfleet")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);       

builder.Build().Run();
